using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class TabsPage : TabbedPage {
    public TabsPage() {
      InitializeComponent();
    }

    public static System.Xml.Linq.XElement XML { get; set; }
    public static Func<System.Xml.Linq.XElement> GetXML { get; set; }
    public static Action UpdateXML { get; set; }



    private void tbiUpdateManually_Clicked(object sender, EventArgs e) {
      UpdateXML();
      XML = GetXML();
      //this.DisplayAlert("Warning", "This feature is not ready yet and thus does nothing", "Ok");
    }
  }
}
