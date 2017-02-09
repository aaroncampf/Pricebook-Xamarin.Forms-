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

    private void tbiUpdateManually_Clicked(object sender, EventArgs e) {
      this.DisplayAlert("Warning", "This feature is not ready yet and thus does nothing", "Ok");
    }
  }
}
