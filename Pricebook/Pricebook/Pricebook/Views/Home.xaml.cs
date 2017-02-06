using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class Home : ContentPage {
    public string MainText { get; set; } = "Hello World";
    public List<Database.INVMAS> INVMAS_Table { get; private set; }


    public Home() {
      InitializeComponent();
      this.BindingContext = this;



      var CSV_INVMAS = Pricebook.Properties.Resources.INVMAS;
      var Test = new System.IO.StringReader(CSV_INVMAS);
      INVMAS_Table = new CsvHelper.CsvReader(Test).GetRecords<Database.INVMAS>().ToList();

      //dgdCustomer.Children.Add(new Label() { Text = "111111111111111111111111111111" });
      //dgdCustomer.Children.Add(new Label() { Text = "222222222222222222222222222222" }, 2, 3, 1, 3);

      listView.ItemsSource = INVMAS_Table;


    }
  }
}
