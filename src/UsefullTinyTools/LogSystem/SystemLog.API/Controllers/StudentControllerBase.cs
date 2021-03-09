using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SystemLog.API.Controllers
{
    [ApiController]
    [Route("api/Log/Student/[controller]/[action]")]
    public class StudentControllerBase : Controller
    {
    }
}
