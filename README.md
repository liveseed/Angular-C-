# Event App - Angular / C# .Net Core Project

***project under development***

A WEB APP Project using Angular and .NET tenologies. In order to keep learning more about the enviroment and how the server-side comunicate with the client-side I did a step forward to get this two guys talking together. I'm curious to see how JWT link the comunication between the front-end and back-end.

To build this App and Web Api solution I used Entity Framework with Migration to interact with SQL Express Database. I am also implementing JWT to create a register/login for this App. 



## Technologies used

* [ASP.NET CORE REST API](https://dotnet.microsoft.com/apps/aspnet/apis). 
* [Angular 9](https://angular.io/). 
* [Migrations Entity Framework](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli). 
* [Swagger](https://swagger.io/about/). 
* [JWT](https://jwt.io/). 

```bash

```
## Road Map 

### Back-End
- [x] Basic Rest Api Structure 
- [x] Controlers
- [x] Domains
- [x] Services 
- [x] Respositories
- [x] Datebase (SQLExpress)
- [ ] Register / Loging (JWT)
- [ ] Implement Swagger
- [ ] AutoMapper & DTO Data Annotations

| Services / Repository | Get | Post | Put | Delete
:------------ | :-------------| :-------------| :-------------| :-------------
|Event |:heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark:
|Headline |:construction_worker: | :construction_worker: | :construction_worker: | :construction_worker:
|Release |:construction_worker: | :construction_worker: | :construction_worker: | :construction_worker:
|SocialNetwork |:construction_worker: | :construction_worker: | :construction_worker: | :construction_worker:


### Front-End
- [x] Basic Angular App structure
- [x] Nav structure   
- [x] Models
- [ ] Services 
- [ ] Register / Login (jwt)


| Services | Get | Post | Put | Delete
:------------ | :-------------| :-------------| :-------------| :-------------
|Event |:heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark:
|Headline |:construction_worker: | :construction_worker: | :construction_worker: | :construction_worker:
|Release |:construction_worker: | :construction_worker: | :construction_worker: | :construction_worker:
|SocialNetwork |:construction_worker: | :construction_worker: | :construction_worker: | :construction_worker:

## Installation

### Changes you need to do

* Clone or download the project 

In order to execute this App from anywhere in my local network I put some not recommendable static 
information. So you need to make some small changes.

In the file: 
`
..\AngularDotNetProject\Angular-app\src\app\_services\Event.service.ts`

Change the baseURL variable for the name of the computer you are using to host the app/server
`
baseURL = 'http://<NAME-OF-YOUR-COMPUTER>:5002/api/event'
`

### Running 

* Back-end: run with command line 'dotnet run' in the .net project directory  
* Front-end: run with command line 'ng-serve' in the angular project directory  

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Feedback 

Any feedback is welcome as I'm learning and really apreciated all kind of advices that will make me to improve. Many thanks! :thumbsup: 

## License
[MIT](https://choosealicense.com/licenses/mit/)
