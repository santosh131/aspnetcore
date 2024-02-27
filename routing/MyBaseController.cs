using Microsoft.AspNetCore.Mvc;

namespace routing
{
    [ApiController]
    [Route("[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class MyBaseController: ControllerBase
    {
    }
}
