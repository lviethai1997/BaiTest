Asp.net MVC 6 project

1.	Install Tools :
	• .net framework 4.8
	•.net 6.0
	•MS 2022
	•SQL Server 2019

2.	How to run project:
	•Clone code from Github : git clone https://github.com/lviethai1997/BaiTest.git
	•Open BaiTest.sln in Visual Studio 
	•Set startup project Data
	•Change connection string in Appsetting.json and SystemConstants.SQLcnn in Data project
	•Open Tools --> Nuget Package Manager --> Package Manager Console in Visual Studio
	•Run Update-database and Enter.
	•Set multiple run project: Right click to Solution and choose Properties and set Multiple Project, choose Start for 2 Projects: AdminApplication, WebClientApplication.
	•Choose profile to run or press F5

3.	If you want up project to ISS:
	•Change SystemConstants.baseURL to URL of AdminApplication  in Data project
	•You also have to install .net hosting bundle 6.0 and .net framework 4.8 runtime

