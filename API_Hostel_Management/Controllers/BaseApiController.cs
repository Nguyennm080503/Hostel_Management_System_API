using Microsoft.AspNetCore.Mvc;

namespace API_Hostel_Management.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected int GetLoginAccountId()
    {
        try
        {
            return int.Parse(this.User.Claims.First(i => i.Type == "AccountID").Value);
        }
        catch (Exception e)
        {
            return 0;
        }
    }

    protected int GetLoginAccounRole()
    {
        try
        {
            return int.Parse(this.User.Claims.First(i => i.Type == "Role").Value);
        }
        catch (Exception e)
        {
            return -1;
        }
    }
    }
}
