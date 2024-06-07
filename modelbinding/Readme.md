# Model Binding
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

## Collections
Model binding looks for matches to parameter_name
Form or query string data can be bound in one of the following formats  
```
 public IEnumerable<WeatherForecast> GetWeatherForecastsMultiple([FromQuery]int[] ids){

 }

 .../GetWeatherForecastsMultiple?ids[0]=21&ids[1]=22


 public IEnumerable<WeatherForecast> GetWeatherForecastsDictionary([FromQuery] Dictionary<int, string> contact){

 }

 .../GetWeatherForecastsDictionary?contact[0]=sam&contact[1]=tim
 .../GetWeatherForecastsDictionary?contact[0].Key=101&contact[0].Value=sam&contact[1].Key=102&contact[1].Value=tim
```