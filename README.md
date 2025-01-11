# AppoinmentManagement
Used Technology: Asp.net Core 8, MSSQL, Postman

Coding Structure: Microservice, CLEAN Architechture, MediatR, JWT Token.

Here are the instructions for running this project:
1.	Download/Clone the application from GIT hub
2.	I have created the project in Micro-service Concept and make separate project for AUTH, so that this auth application can be used in other project. 
3.	Before running this application, Migration has been needed for Database.
3.1	First set Users.API  as startup project and Users.Infrastractures as default project
3.2	Change the Database Connection string in appsettings.json of User.API
3.3	 Run this command in Package Manager Console:=>  update-database
3.4	And then set Appointments.API as startup project and change the Database Connection string in appsettings.json of Appointments.API and Appointments.Infrastractures. 
3.5	Run this command in Package Manager Console:=>  update-database
4.	After running the migration a demo user will be created. 
User name: demo
Password: s123456
5.	Configure multiple start up project and select Users.API and Appoinments.API as start-up project.
6.	Login into the application from user api and after successful login an access-token has been generated.
7.	Copy the access token and authorize the Appointment API. E.g: Bearer access token
8.	And now user can create Doctor, Appointment, update Appointment, Get Appoinment by id, Delete Appointment.
9.	For Appointment Create and Update single endpoint “/Appointment/push” is created. When user will Appointment with existing id it will update, otherwise insert.
10.	For automated testing I have created a Postman script.
11.	Import this script in your Postman application.
12.	Please change the variable like userUrl and appointmentUrl by your own.
13.	Run the collection and you will get the result for all the API End-Points
