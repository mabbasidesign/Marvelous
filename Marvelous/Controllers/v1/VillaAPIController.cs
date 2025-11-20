using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

//Task 1: Setup Controller and Dependencies
//Description:
//Create the TestAPIController with required dependencies.
//Technical Details:
//Use ControllerBase.
//Inject IVillaRepository and IMapper.
//Initialize _response with APIResponse.
//Add [ApiController] and[Route("api/v{version:apiVersion}/VillaAPI")].
//Add[ApiVersion("1.0")].
//Acceptance Criteria:
//Controller compiles successfully.
//_villaRepo and _mapper are available for all methods.
//_response object initialized correctly.

namespace Marvelous.Controllers.v1
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class VillaAPIController : ControllerBase
    //{
    //    [HttpGet]
    //    public IActionResult TestAPIController()
    //    {
    //        return Ok("Villa API Controller v1 is working!");
    //    }
    //}


    [Route("api/[controller]")]
    public class VillaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllVillas()
        {
            return Ok();
        }

        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "String1", "string2" };
        }
    }


}
