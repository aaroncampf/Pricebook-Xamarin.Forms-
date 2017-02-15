using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class CustomersPage : ContentPage {
    public ObservableCollection<Database.ARCUST> ARCUSTs_Full { get; private set; } = new ObservableCollection<Database.ARCUST>();
    public ObservableCollection<Database.ARCUST> ARCUSTs { get; private set; } = new ObservableCollection<Database.ARCUST>();

    public ObservableCollection<Database.ORDERFRM_Plus> ORDERFRM_Plus_Data { get; private set; } = new ObservableCollection<Database.ORDERFRM_Plus>();


    public CustomersPage() {
      InitializeComponent();
      this.BindingContext = this;
      Xamarin.Forms.DataGrid.DataGridComponent.Init();

      /*
      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(Properties.Resources.ARCUST)).GetRecords<Database.ARCUST>()) {
        ARCUSTs_Full.Add(item);
        ARCUSTs.Add(item);
      }

      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(Properties.Resources.ORDERFRM_Plus)).GetRecords<Database.ORDERFRM_Plus>()) {
        ORDERFRM_Plus_Data.Add(item);
      }
      */

      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(TabsPage.XML.Element("ARCUST").Value)).GetRecords<Database.ARCUST>()) {
        ARCUSTs_Full.Add(item);
        ARCUSTs.Add(item);
      }

      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(TabsPage.XML.Element("ORDERFRM_Plus").Value)).GetRecords<Database.ORDERFRM_Plus>()) {
        ORDERFRM_Plus_Data.Add(item);
      }
    }

    private void gridCustomers_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
      Navigation.PushAsync(new CustomerPage(e.SelectedItem as Database.ARCUST, ORDERFRM_Plus_Data));
    }

    private void txtFilter_TextChanged(object sender, TextChangedEventArgs e) {
      ARCUSTs.Clear();
      var Items = ARCUSTs_Full.Where(x => x.COMPANYNM.ToLower().StartsWith(txtFilter.Text.ToLower()) || x.CUSTNO.ToLower().StartsWith(txtFilter.Text.ToLower()));

      foreach (var item in Items) {
        ARCUSTs.Add(item);
      }
    }
  }
}
