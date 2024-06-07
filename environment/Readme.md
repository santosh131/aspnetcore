# Setting Environment variable

Application will try to find & use appsetting.json related to that environment. 
For example: If the application runs in Staging environment then appsettings.Staging.json is used, if the file is not found the appsettings.json is used.  
  
The environment for local machine development can be set in the Properties\launchSettings.json file of the project. 

Environment values set in **launchSettings.json** override values set in the system environment

The launchSettings.json file:  

- Is only used on the local development machine.  
- Is not deployed.  
- Contains profile settings.  

If nothing is mentioned in the lauchSettings.json then the default is "Production".

To set the ASPNETCORE_ENVIRONMENT for the current session when the app is started using dotnet run, use the following commands at in PowerShell  

```
$Env:ASPNETCORE_ENVIRONMENT = "Staging"  
dotnet run --no-launch-profile  
```

> Setting this way, the application will run in the applied environemnt (eg: Staging) for the current session/context only