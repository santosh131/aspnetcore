# Areas  
## Add Area with Visual Studio

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