# Pricebook-Xamarin.Forms-
An Android pricebook for AJP Northwest created using Xamarin.Forms, Dropbox.Api and CsvHelper.

## Overview



## Pricebook Tab
Displays all records in the pricebook (table: INVMAS)

### Filtering
* By String
* By Vendor
* By Customer

## Customers Tab

### Filtering


## 

## Data
Data comes from the AJP application Join Data Uploader which uploads data onto Dropbox Where each application is services gets a single file just for it.
The file is an xml file with the following structure 

<Database>

	<APVENDOR>
	
		<%= CSV %>
		
	</APVENDOR>
	
	<ARCUST>
	
		<%= CSV %>
		
	</ARCUST>
	
	<INVGROUP>
	
		<%= CSV %>
		
	</INVGROUP>
	
	<INVMAS>
	
		<%= CSV %>
		
	</INVMAS>
	
	<ORDERFRM_Plus>
	
		<%= CSV %>
		
	</ORDERFRM_Plus>
	
</Database>
