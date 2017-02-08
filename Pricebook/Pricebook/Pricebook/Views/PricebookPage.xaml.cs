using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class PricebookPage : ContentPage {
    public string MainText { get; set; } = "Hello World";
    //public List<Database.INVMAS> INVMAS_Table { get; private set; 
    public ObservableCollection<Database.INVMAS> INVMAS_Table { get; private set; } = new ObservableCollection<Database.INVMAS>();


    public PricebookPage() {
      InitializeComponent();
      this.BindingContext = this;
      Xamarin.Forms.DataGrid.DataGridComponent.Init();


      var CSV_INVMAS = Pricebook.Properties.Resources.INVMAS;
      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(CSV_INVMAS)).GetRecords<Database.INVMAS>()) {
        INVMAS_Table.Add(item);
      }

      /*
      foreach (var item in INVMAS_Table.Take(INVMAS_Table.Count - 10).ToList()) {
        INVMAS_Table.Remove(item);
      }
      */
    }

    private void GridTest_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
      Navigation.PushAsync(new ProductPage((Database.INVMAS)e.SelectedItem));
    }

    private void GridTest_Refreshing(object sender, EventArgs e) {
      throw new NotImplementedException();
    }
  }
}
