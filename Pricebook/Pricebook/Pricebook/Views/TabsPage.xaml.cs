using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class TabsPage : TabbedPage {

    #region Properties      

    /// <summary>The loaded XML data for the whole application</summary>
    public static System.Xml.Linq.XElement XML { get; set; }
    /// <summary>A function that gets the data to be set at <see cref="XML"/></summary>
    public static Func<System.Xml.Linq.XElement> GetXML { get; set; }
    /// <summary>An Action that updates the XML after the data is specified number of days old</summary>
    public static Action<int> UpdateXML { get; set; }

    #endregion

    public TabsPage() {
      InitializeComponent();
      UpdateData(false);
    }

    private void UpdateData(bool UpdateNow) {
      UpdateXML(UpdateNow ? 0 : 3);
      XML = GetXML();

      if (TabsPage.XML == null) {
        Device.BeginInvokeOnMainThread(() => {
          DisplayAlert("Error in Data", "Please manually refresh data", "Okay");
        });
      }
      else {
        pagePrices.RefreshData();
        pageCustomers.RefreshData();
      }
    }

    private void tbiUpdateManually_Clicked(object sender, EventArgs e) {
      UpdateData(true);
    }
  }
}
