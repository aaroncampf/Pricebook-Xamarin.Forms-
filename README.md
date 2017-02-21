# Pricebook-Xamarin.Forms-
An Android price book for AJP Northwest created using C#, Xamarin.Forms, Dropbox.Api and CsvHelper.

## Overview


## Disclaimer
This was built for AJP Northwest and uploaded with permission in return a free prototype.


## Pricebook Tab
Displays all records in the pricebook (table&nbsp;&nbsp;&nbsp; INVMAS)

### Filtering
* By String
* By Vendor
* By Customer

## Customers Tab

### Filtering
* By String

## 

## Data
Data comes from the AJP application Join Data Uploader which uploads data onto Dropbox where each application is treated as a service and gets a single file uploaded just for it to use.
The file is an xml file with the following structure 

&nbsp;&nbsp;&nbsp; Database

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; APVENDOR

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CSV

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ARCUST

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CSV

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; INVGROUP

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CSV

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; INVMAS

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CSV

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ORDERFRM_Plus

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CSV