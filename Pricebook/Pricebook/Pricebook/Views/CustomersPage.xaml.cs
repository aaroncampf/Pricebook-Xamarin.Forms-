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
      Xamarin.Forms.DataGrid.DataGridComponent.Init();
    }

    public void RefreshData() {
      ARCUSTs_Full.Clear();
      ARCUSTs.Clear();
      ORDERFRM_Plus_Data.Clear();
      gridCustomers.ItemsSource = null;

      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(TabsPage.XML.Element("ARCUST").Value)).GetRecords<Database.ARCUST>()) {
        ARCUSTs_Full.Add(item);
        ARCUSTs.Add(item);
      }

      foreach (var item in new CsvHelper.CsvReader(new System.IO.StringReader(TabsPage.XML.Element("ORDERFRM_Plus").Value)).GetRecords<Database.ORDERFRM_Plus>()) {
        ORDERFRM_Plus_Data.Add(item);
      }

      gridCustomers.ItemsSource = ARCUSTs;
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

    /*
    protected override void OnAppearing() {
      base.OnAppearing();

      if (TabsPage.XML == null) {
        Device.BeginInvokeOnMainThread(() => {
          DisplayAlert("Error in Data", "Please manually refresh data", "Okay");
        });
      }
      else if(!ARCUSTs_Full.Any()) {
        RefreshData();
      }

      gridCustomers.HeightRequest.ToString();
      gridCustomers.ToString();
      layoutMain.ToString();
    }
    */
  }
}
