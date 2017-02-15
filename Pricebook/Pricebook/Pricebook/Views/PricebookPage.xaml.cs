using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class PricebookPage : ContentPage {
    public List<Database.INVMAS> INVMAS_Table_Full { get; private set; } = new List<Database.INVMAS>();
    public ObservableCollection<Database.INVMAS> INVMAS_Table { get; private set; } = new ObservableCollection<Database.INVMAS>();
    public ObservableCollection<Database.INVGROUP> GroupListItems { get; private set; } = new ObservableCollection<Database.INVGROUP>();
    public ObservableCollection<Database.APVENDOR> APVENDOR_Smalls { get; private set; } = new ObservableCollection<Database.APVENDOR>();


    public PricebookPage() {
      InitializeComponent();
      this.BindingContext = this;
      Xamarin.Forms.DataGrid.DataGridComponent.Init();

      RefreshData();
    }


    public void RefreshData() {
      APVENDOR_Smalls.Clear();
      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(TabsPage.XML.Element("APVENDOR").Value)).GetRecords<Database.APVENDOR>()) {
        APVENDOR_Smalls.Add(item);
      }

      INVMAS_Table_Full.Clear();
      INVMAS_Table.Clear();
      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(TabsPage.XML.Element("INVMAS").Value)).GetRecords<Database.INVMAS>()) {
        INVMAS_Table_Full.Add(item);
        INVMAS_Table.Add(item);
      }

      GroupListItems.Clear();
      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(TabsPage.XML.Element("INVGROUP").Value)).GetRecords<Database.INVGROUP>()) {
        GroupListItems.Add(item);
      }
    }

    private void btnFilterByGroup_Clicked(object sender, EventArgs e) {
      var Form = new GetGroupFilter(GroupListItems);
      Navigation.PushModalAsync(Form);

      Form.Disappearing += (sender1, e1) => {
        if (string.IsNullOrEmpty(Form.SelectedGroup)) return;

        var Items = INVMAS_Table_Full.Where(x => x.GROUP.Contains(Form.SelectedGroup));
        INVMAS_Table.Clear();
        foreach (var item in Items) {
          INVMAS_Table.Add(item);
        }
      };
    }

    private void btnFilterByVendor_Clicked(object sender, EventArgs e) {
      var Form = new GetVendor(APVENDOR_Smalls);
      Navigation.PushModalAsync(Form);

      Form.Disappearing += (sender1, e1) => {
        if (string.IsNullOrEmpty(Form.SelectedVendorID)) return;

        var Items = INVMAS_Table_Full.Where(x => x.VENDORID == Form.SelectedVendorID);
        INVMAS_Table.Clear();
        foreach (var item in Items) {
          INVMAS_Table.Add(item);
        }
      };
    }

    private void btnClearFilter_Clicked(object sender, EventArgs e) {
      INVMAS_Table.Clear();
      foreach (var item in INVMAS_Table_Full) {
        INVMAS_Table.Add(item);
      }
    }

    private void txtFilter_TextChanged(object sender, TextChangedEventArgs e) {
      INVMAS_Table.Clear();
      var Items = INVMAS_Table_Full.Where(x => x.DESCRIP.ToLower().StartsWith(txtFilter.Text.ToLower()) || x.ITEMNO.ToString().ToLower().StartsWith(txtFilter.Text.ToLower()));

      foreach (var item in Items) {
        INVMAS_Table.Add(item);
      }
    }

    private void GridTest_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
      Navigation.PushModalAsync(new ProductPage((Database.INVMAS)e.SelectedItem));
    }
  }
}
