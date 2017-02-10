using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class PricebookPage : ContentPage {
    //public ObservableCollection<Database.INVMAS> INVMAS_Table_Full { get; private set; } = new ObservableCollection<Database.INVMAS>();
    public List<Database.INVMAS> INVMAS_Table_Full { get; private set; } = new List<Database.INVMAS>();
    public ObservableCollection<Database.INVMAS> INVMAS_Table { get; private set; } = new ObservableCollection<Database.INVMAS>();

    public ObservableCollection<Database.INVGROUP_Small> GroupListItems { get; private set; } = new ObservableCollection<Database.INVGROUP_Small>();

    public PricebookPage() {
      // var DFile = Database.Passwords.DBox.Files.DownloadAsync("/Storage/Pricebook.xml").Result;








      InitializeComponent();
      this.BindingContext = this;
      Xamarin.Forms.DataGrid.DataGridComponent.Init();

      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(Properties.Resources.INVMAS)).GetRecords<Database.INVMAS>()) {
        INVMAS_Table_Full.Add(item);
        INVMAS_Table.Add(item);
      }

      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(Properties.Resources.INVGROUP_Small)).GetRecords<Database.INVGROUP_Small>()) {
        GroupListItems.Add(item);
      }
    }

    private void btnFilterByGroup_Clicked(object sender, EventArgs e) {
      var Form = new GetGroupFilter(GroupListItems);
      Navigation.PushModalAsync(Form);

      Form.Disappearing += (sender1, e1) => {
        var Items = INVMAS_Table_Full.Where(x => x.GROUP.Contains(Form.SelectedGroup));

        INVMAS_Table.Clear();
        foreach (var item in Items) {
          INVMAS_Table.Add(item);
        }
      };
    }

    private void btnFilterByVendor_Clicked(object sender, EventArgs e) {
      throw new NotImplementedException();
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
      //Navigation.PushAsync(new ProductPage((Database.INVMAS)e.SelectedItem));
      Navigation.PushModalAsync(new ProductPage((Database.INVMAS)e.SelectedItem));
    }
  }
}
