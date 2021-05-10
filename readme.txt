Steps to follow:
Step 1.
-> Run SQL Script in Database and Change the Database Server name and Database Name in Web.config file.
Note: i have attached SQL Script.

Step 2.
-> Run Web Api Project and Open Postman

Step 3.
-> I have create 4 api method for different operation:

1st Method : Add New Item

 -> Select Method type POST
 -> Api Url: https://localhost:44317/api/AddNewItem
 -> Pass Parameter: ItemName,ItemDescription,ItemPrice,ItemCategory,ImageFileName,ImageFileExtension,ImageFilePath,CreatedBy
 -> Example Input Parameter:
	 ItemName : Apple Mobile
	 ItemDescription : Smart phone designed by apple
 	 ItemPrice : 50000.00
	 ItemCategory : Electronics
	 ImageFileName : mobileone.jpg
	 ImageFileExtension : .jpg
	 ImageFilePath : https://www.thechennaimobiles.com/image/cache/catalog/f19p-slr-600x600.jpg
	 CreatedBy : Ranjan Sharma

 -> OUTPUT:
	IsValid : true
	Message : Item Saved Successfully


2nd Method : Get All Items

 -> Select Method type GET
 -> Api Url: https://localhost:44317/api/GetItems
 -> OUTPUT:
	{
	 ItemName : Apple Mobile
	 ItemDescription : Smart phone designed by apple
 	 ItemPrice : 50000.00
	 ItemCategory : Electronics
	 ImageFileName : mobileone.jpg
	 ImageFileExtension : .jpg
	 ImageFilePath : https://www.thechennaimobiles.com/image/cache/catalog/f19p-slr-600x600.jpg
	 CreatedBy : Ranjan Sharma
	}

3rd Method : Modify/Update Item

 -> Select Method type PUT
 -> Api Url: https://localhost:44317/api/UpdateItem
 -> Pass Parameter: ItemId,ItemName,ItemDescription,ItemPrice,ItemCategory,CreatedBy
 -> Example Input Parameter:
ItemName : Apple Mobile
	 ItemName : Sumsung Mobile
	 ItemDescription : Sumsung Mobile designed
 	 ItemPrice : 15000.00
	 ItemCategory : Electronics
	 ImageFileName : samsungmobile.jpg
	 ImageFileExtension : .jpg
	 ImageFilePath : https://www.thechennaimobiles.com/image/cache/catalog/f19p-slr-600x600.jpg
	 CreatedBy : Ranjan Sharma

 -> OUTPUT:
	IsValid : true
	Message : Item Updated Successfully

4th Method : Delete Item

 -> Select Method type DELETE
 -> Api Url: https://localhost:44317/api/DeleteItem
 -> Pass Parameter: ItemId
 -> Example Input Parameter:
	 ItemId : 1

 -> OUTPUT:
	IsValid : true
	Message : Item Delete Successfully







