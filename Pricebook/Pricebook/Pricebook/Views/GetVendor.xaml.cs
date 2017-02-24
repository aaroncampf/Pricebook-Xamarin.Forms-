using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class GetVendor : ContentPage {
    public List<Database.APVENDOR> Cache { get; private set; } = new List<Database.APVENDOR>();
    public ObservableCollection<Database.APVENDOR> Table { get; private set; } = new ObservableCollection<Database.APVENDOR>();
    public string SelectedVendorID { get; set; }


    public GetVendor(ObservableCollection<Database.APVENDOR> APVendors) {
      InitializeComponent();
      this.BindingContext = this;
      Xamarin.Forms.DataGrid.DataGridComponent.Init();

      foreach (var item in APVendors) {
        this.Cache.Add(item);
        this.Table.Add(item);
      }
    }
    
    private void GrdData_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
      SelectedVendorID = (e.SelectedItem as Database.APVENDOR).VENDORID;
      this.Navigation.PopModalAsync();
    }

    private void txtFilter_TextChanged(object sender, TextChangedEventArgs e) {
      Table.Clear();
      var Items = Table.Where(x => x.COMPANYNM.ToLower().StartsWith(txtFilter.Text.ToLower()) || x.VENDORID.ToLower().StartsWith(txtFilter.Text.ToLower()));

      foreach (var item in Items) {
        Cache.Add(item);
      }
    }
  }
}
