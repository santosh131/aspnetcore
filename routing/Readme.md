# Routing
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