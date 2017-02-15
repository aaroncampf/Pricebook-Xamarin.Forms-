using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricebook.Database;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Pricebook.Views {
  public partial class CustomerPage : ContentPage {

    public CustomerPage(ARCUST SelectedCustomer, ObservableCollection<ORDERFRM_Plus> OrderformData) {
      InitializeComponent();
      this.BindingContext = this;

      var htmlSource = new HtmlWebViewSource();
      htmlSource.Html = $@"
                          <h1>{SelectedCustomer.COMPANYNM}</h1>
                          <p>CUSTNO: {SelectedCustomer.CUSTNO}</p>
                          <p>Address: {SelectedCustomer.ADDRESS1}</p>
                          <p>City: {SelectedCustomer.CITY}</p>
                          <p>State: {SelectedCustomer.STATE}</p>
                          <p>Zip: {SelectedCustomer.ZIP}</p>
                          <p>Person: {SelectedCustomer.PERSON}</p>
                          <p>Phone: {SelectedCustomer.PHONE}</p>
                          <p>Fax: {SelectedCustomer.FAX}</p>
                          <p>Email: {SelectedCustomer.EMAIL}</p>
                          <h2>Price Book</h2>
                        ";

      foreach (var item in OrderformData.Where(x => x.SHIPCUSTNO == SelectedCustomer.CUSTNO)) {
        htmlSource.Html += $@"
          <h3>{item.DESCRIP}</h3>
          <p>LastSellNetnet: {item.LastSellNetnet}</p>
          <p>EntryDate: {item.EntryDate}</p>
          <p>Category: {item.CATG}</p>
          <p>Group: {item.GROUP}</p>
          <p>DESCRIP2: {item.DESCRIP2}</p>
          <p>DESCRIP3: {item.DESCRIP3}</p>
        ";
      }
      webMain.Source = htmlSource;
    }
  }
}
