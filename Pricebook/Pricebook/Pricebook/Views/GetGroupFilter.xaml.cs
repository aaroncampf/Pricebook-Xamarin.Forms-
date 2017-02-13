using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricebook.Database;
using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class GetGroupFilter : ContentPage {
    public List<INVGROUP> Cache { get; private set; } = new List<INVGROUP>();
    public ObservableCollection<INVGROUP> Table { get; private set; } = new ObservableCollection<INVGROUP>();
    public string SelectedGroup { get; set; }

    public GetGroupFilter(ObservableCollection<INVGROUP> groupListItems) {
      InitializeComponent();
      this.BindingContext = this;
      Xamarin.Forms.DataGrid.DataGridComponent.Init();

      //this.Table = groupListItems;
      foreach (var item in groupListItems) {
        this.Cache.Add(item);
        this.Table.Add(item);
      }
    }

    /*
     public static string GetGroup(INavigation Navigation, ObservableCollection<Database.INVGROUP_Small> Items) {
       var Form = new GetGroupFilter() { Table = Items };
       Navigation.PushModalAsync(Form);

       return Form.SelectedGroup;
     }
     */
    private void GrdData_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
      SelectedGroup = (e.SelectedItem as Database.INVGROUP).GROUP;
      this.Navigation.PopModalAsync();
    }


    private void txtFilter_TextChanged(object sender, TextChangedEventArgs e) {
      Table.Clear();
      var Items = Cache.Where(x =>
                                  x.GROUP.ToLower().StartsWith(txtFilter.Text.ToLower()) ||
                                  x.DESCRIP.ToLower().StartsWith(txtFilter.Text.ToLower())
                             );

      foreach (var item in Items) {
        Table.Add(item);
      }
    }
  }
}
