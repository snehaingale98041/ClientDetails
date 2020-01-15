# ClientDetails
Maintaining contact information of Client using Web API and MVC entity framework.

Project Description:
Design and implement a production ready application for maintaining contact information.

Tasks:
•	List contacts
•	Add a contact
•	Edit contact
•	Delete/Inactivate a contact

Tools Used:
•	Database : SQL Server 2019 
•	Entity Framework : version 6 
•	IDE used : Visual Studio 2019 ,MVC based Web API

Working: 
There are 2 projects in solution as follows 
•	ClientDetails(API Project) 
•	MVCClientDetails(MVC Project.)

ClientDetails(API Project):  
•	It contains 1 entity model tblClientDetail and controller i.e. tblClientDetailsController.
•	tblClientDetail model contains the get set properties for parameters like name,email,phoneno,gender, etc.
•	Controller contains methods used to list,create,update and delete clients details.

MVCClientDetails(MVC Project.):
	
•	It contains model named MVCClinetDetailsModel which is having the multiple parameters. Here we can set the validations also. 	 You can see the Id field have “required” attribute.
•	It contains controller named MVCClientDetailsController which contains different actionresult methods like index (to list),    	   AddOrEdit(to update), Delete(to delete) the client details.
•	It contains views Index(list and delete) and AddOrEdit(create and update).
•	I have provide validations for email address and phone no.


**I have used alertifyjs to provide alert messages on each functionality.

GlobalVariables.cs :
•	I have create GlobalVariables.cs file to communicate between Web API and my MVC project.
•	In this I had create instance of HttpClient and use this HttpClient instance to access the methods from Web API project.


 
