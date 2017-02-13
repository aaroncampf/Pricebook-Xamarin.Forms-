using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class GetVendor : ContentPage {
    public List<Database.APVENDOR_Small> Cache { get; private set; } = new List<Database.APVENDOR_Small>();
    public ObservableCollection<Database.APVENDOR_Small> Table { get; private set; } = new ObservableCollection<Database.APVENDOR_Small>();
    public string SelectedVendorID { get; set; }


    public GetVendor(ObservableCollection<Database.APVENDOR_Small> APVendors) {
      InitializeComponent();
      this.BindingContext = this;
      Xamarin.Forms.DataGrid.DataGridComponent.Init();

      foreach (var item in APVendors) {
        this.Cache.Add(item);
        this.Table.Add(item);
      }
    }


    private void GrdData_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
      SelectedVendorID = (e.SelectedItem as Database.APVENDOR_Small).VENDORID;
      this.Navigation.PopModalAsync();
    }



  }
}
