# Alten Fleet management System - microservices - 

**Prerequisites for the Application**

1- Windows 10 Pro or Enterprise version 14393, or Windows server 2016 RTM -for the docker-

2- Node.js

**How to run the application**

1- Clone or download the application from repository.

2- Open the solution file, it will asks you to enable the feature of docker if you don't  already have it.

3- Restore Nugent packages & Build the solution.

4- Change or create the db on the connection found in 

	4.1- FleetManager.Repository/SQLHelper.cs --> connection
	
	4.2- VehicleTracker.Repository/SQLHelper.cs --> connection
	
5- To run without docker

	5.1- Inside VisualStudio set the startup project multiple for those projects
	
		5.1.1- Apps.SPA
		
		5.1.2- FleetManager.API
		
		5.1.3- StatusGenerator
		
		5.1.4- VehicleTracker.API
		
6- I used the chrome extension "Allow-Control-Allow-Origin: *" to allow debugging and running it locally

**Issue may faces you** 

1- in case of error "Webpack dev middleware failed... ", go to SPA app --> dependacies -->  npm and restore packages.

2- in case of error "There is already an object named '__MigrationHistory'", rebuild all projects again.

**What is still missing or incomplete 

1- Completion error / exception handling 

2- Guid of how to transform it to server-less architecture using aws lambda framework-

3- Using event-bus pattern to enhance performance and to completed follow microservies architecture

6- Reach a decent test coverage using unit, integration, and automation tests

7- Integrate with CI/CD tool -appveyor- 

8- Enhance the webapis with swagger

		
