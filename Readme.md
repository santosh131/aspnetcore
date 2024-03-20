# ASP.net Core
### Setting Environment variable

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

### Routing  
Asp.net core inspects incoming HTTP requests and maps them to applications executable Endpoint  
An endpoint is an object that contains eveything that is needed to execute the Request.  

**UseRouting**: Urls are matched to the endpoints.  
Its purpose is to
- Parse the incoming URL.  
- Resolve the URL and construct the Endpoint.  
- Updates the HTTP context with endpoint.  
The middleware running after UseRouting can access the endpoint from the HTTP context and take action.  

**UseEndPoints**: Actual EndPoints are registered/executed.  
EndPointMiddleware is responsible for the execution of EndPoint  
It reads the endpoint, which was selected by Route Matching middleware and runs the delegate associated with it.
MapGet: Creates the custom endpoints  
We can also create the endpoints using the map methods like **MapPost, MapPut, MapDelete & Map**  
Middleware after UseEndPoints execute only when no match is found.  

## Routing to Controller Action
Actions are either **conventionally-routed** or **attribute-routed**  

## Attribute Routing
Placing a route on the Controller or Action makes it attribute routed.  
Placing a route attribute on the controller makes all actions in the controller use attribute routing.  
Attribute routes can also be combined with inheritance(look for **MyBaseController**)  
Attribute routing can use HttpMethodAttribute attributes such as **HttpPostAttribute, HttpPutAttribute, and HttpDeleteAttribute**  
All of the HTTP verb attributes accept a route template.
Once the route is added to HTTP verb attribute, Route attribute is not needed

## Conventional Routing
Conventional Routing is used with Controllers and Views.  
Conventional Routing are not displayed in Swagger

### Areas
##Add Area with Visual Studio

-In Solution Explorer, right click the project and Select ADD > New Scaffolded Item, then select MVC Area  

-Once the areas are added, add the following lines in the Program.cs  
```
app.UseEndPoints(endpoints =>{  
 endpoints.MapControllerRoute(  
	name: "Myarea",
	pattern: "{areas:exists}/{controller=Home}/{action=Index}"  
 );  
});
```

Area routes typically use conventional routing rather tha attribute routing.  
In general, routes with areas should be placed earlier in the route table as they are  
more specific than routes wihtout an Area

To implement areas in Asp.Net core web app using Controllers, Views
- An Area folder structure
- Add Area attribute to Controller - to associate the controller with area
```
[Area("Products")]
public class ProductController: Controller
```

- Area route added to Program.cs
```
app.UseEndPoints(endpoints =>{  
 endpoints.MapControllerRoute(  
	name: "Myarea",
	pattern: "{areas:exists}/{controller=Home}/{action=Index}"  
 );
});
```
To create the **named area routes** 

```app.UseEndPoints(endpoints=>{
	app.MapAreaControllerRoute(
		name:"Products",
		pattern:"Products/{Controller=Home}/{action=Index}"
	);
});

app.UseEndpoints(endpoints=>{
	app.MapAreaControllerRoute(
		name:"Employees",
		pattern:"Employees/{Controller=Home}/{action=Index}"
	);
});
```
- Move the _ViewImports.cshtml, _ViewStart.cshtml outside the **Views** folder, if the Layout has to be used for Views in areas  

### Model Binding
- Retrieves data from various sources such as route data, form fields and query string
- Provides data to controllers and razor pages in method parameters and public properties
- Converts string data to .Net Types
- Updates properties of complex Types

> Add the following code in the Program.cs otherwise the DefaultModelBinder will perform required and datatype validations on value types like int, string, datetime etc. This will happen even if the **[Required]** attribute is not applied.  

```  
builder.Services.AddControllers(options =>  
{  
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;  
});  
```

Model binding gets the data in the form of key-value pairs from the following sources
- FromForm : Values from posted form fields
- FromBody : Values from request body
- FromRoute : Values from Route data
- FromQuery : Values from Query String
- FromHeader: Vlaues from HTTP headers

> When [FromBody] is applied to the complex type parameter, any binding source applied to its properties are ignored  
> Don't apply [FromBody] to more than one parameter per action method.Once the request stream is read the input formatter,it's no longer available to be read again for binding other [FromBody] parameters.  
  
**[BindProperty]** can be applied to public property of controller. Set the **SupportsGet** to **true** to bound data from GET requests.   
**[BindProperties]** can be applied to controller to target all properties of class  
```
[BindProperty(Name="contact_id",SupportsGet=true)]  
public int? ContactId{ get; set; }

[BindProperties(SupportsGet=true)]
public class ContactController:ControllerBase
{

}
```


