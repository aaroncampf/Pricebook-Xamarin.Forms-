using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class Home : ContentPage {
    public string MainText { get; set; } = "Hello World";

    public Home() {
      InitializeComponent();
      this.BindingContext = this;
    }
  }
}
