using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class PricebookPage : ContentPage {
    public ObservableCollection<Database.INVMAS> INVMAS_Table_Full { get; private set; } = new ObservableCollection<Database.INVMAS>();
    public ObservableCollection<Database.INVMAS> INVMAS_Table { get; private set; } = new ObservableCollection<Database.INVMAS>();


    public PricebookPage() {
      InitializeComponent();
      this.BindingContext = this;
      Xamarin.Forms.DataGrid.DataGridComponent.Init();

      var CSV_INVMAS = Properties.Resources.INVMAS;

      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(CSV_INVMAS)).GetRecords<Database.INVMAS>()) {
        INVMAS_Table_Full.Add(item);
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
      Navigation.PushAsync(new ProductPage((Database.INVMAS)e.SelectedItem));
    }

    private void GridTest_Refreshing(object sender, EventArgs e) {
      throw new NotImplementedException();
    }
  }
}
