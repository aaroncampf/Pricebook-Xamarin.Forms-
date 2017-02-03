using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Pricebook {
  public class App : Application {
    public App() {
      // The root page of your application
      //var content = new ContentPage {
      //  Title = "Pricebook",
      //  Content = new StackLayout {
      //    VerticalOptions = LayoutOptions.Center,
      //    Children = {
      //      new Label {
      //        HorizontalTextAlignment = TextAlignment.Center,
      //        Text = "Welcome to Xamarin Forms!"
      //      }
      //    }
      //  }
      //};


      var CSV_INVMAS = Pricebook.Properties.Resources.INVMAS;


      var Test = new System.IO.StringReader(CSV_INVMAS);

      var csv = new CsvHelper.CsvReader(Test);
      var Records = csv.GetRecords<Database.INVMAS>();
      var Final = Records.ToList();

      var content = new Views.Home();

      MainPage = new NavigationPage(content);
    }

    protected override void OnStart() {
      // Handle when your app starts
    }

    protected override void OnSleep() {
      // Handle when your app sleeps
    }

    protected override void OnResume() {
      // Handle when your app resumes
    }
  }
}
