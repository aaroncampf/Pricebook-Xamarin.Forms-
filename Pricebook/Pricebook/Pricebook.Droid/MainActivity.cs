﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Pricebook.Droid {
  [Activity(Label = "Pricebook", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
    protected override void OnCreate(Bundle bundle) {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);

      Views.TabsPage.GetXML = () => {
        //TODO: Find a better way to do this
        try {
          return System.Xml.Linq.XElement.Load($"{Android.OS.Environment.ExternalStorageDirectory.Path}/Aaron/Pricebook_XamarinForms.xml");
        }
        catch {
          return null;
        }
      };

      Views.TabsPage.UpdateXML = (Days) => {
        DownloadData("Pricebook_XamarinForms.xml", Days);
      };

      /*
      DownloadData("Pricebook_XamarinForms.xml", 3);
      Views.TabsPage.XML = Views.TabsPage.GetXML();
      */


      Window.SetSoftInputMode(SoftInput.AdjustResize);
      AndroidBug5497WorkaroundForXamarinAndroid.assistActivity(this);


      global::Xamarin.Forms.Forms.Init(this, bundle);
      LoadApplication(new App());
    }

    protected bool DownloadData(string FileNameWithExtension, double DaysToWaitForUpdate, string DefaultFolder = "Storage") {
      var Folder = $"{Android.OS.Environment.ExternalStorageDirectory.Path}/Aaron";
      var file = new System.IO.FileInfo(Folder + "/" + FileNameWithExtension);

      if (!System.IO.Directory.Exists(Folder)) {
        System.IO.Directory.CreateDirectory(Folder);
      }
      if (!System.IO.File.Exists(Folder + "/" + FileNameWithExtension)) {
        file.Create().Close();

        var File = Passwords.DBox.Files.DownloadAsync($"/{DefaultFolder}/{FileNameWithExtension}").Result;
        var FileData = File.GetContentAsStringAsync().Result;
        System.IO.File.WriteAllText($"{Folder}/{FileNameWithExtension}", FileData);
        return true;
      }
      else if (System.IO.File.GetCreationTime(Folder + $"/{FileNameWithExtension}") < DateTime.Now.AddDays(-DaysToWaitForUpdate)) {
        file.Delete();
        file.Create().Close();

        var File = Passwords.DBox.Files.DownloadAsync($"/{DefaultFolder}/{FileNameWithExtension}").Result;
        var FileData = File.GetContentAsStringAsync().Result;
        System.IO.File.WriteAllText($"{Folder}/{FileNameWithExtension}", FileData);
        return true;
      }

      return false;
    }
  }
}