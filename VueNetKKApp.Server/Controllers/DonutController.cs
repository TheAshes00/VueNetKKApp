using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.DTO;
using VueNetKKApp.Server.DTO.Donut;
using VueNetKKApp.Server.Support;

namespace VueNetKKApp.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DonutController : ControllerBase
    {
        //--------------------------------------------------------------------------------------------------------------
        //                                          INSTANCE VARIABLES
        //--------------------------------------------------------------------------------------------------------------
        private readonly ILogger<DonutController> _logger;
        private IConfiguration _configuration;

        //-------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTORS.
        public DonutController(ILogger<DonutController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            _configuration = iConfig;
        }

        //-------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]/")]
        public IActionResult GetAllDonutTypes(
        )
        {
            ServansdtoServiceAnswerDto servansdto;
            using var context = new DonutsContext();

            try
            {
                List<GetalldonGetAllDonutDto.Out> darr = DonDonuts.arrGetAllDonuts(context);
                servansdto = new(200, darr);
            }
            catch (
                Exception ex
            )
            {
                servansdto = new ServansdtoServiceAnswerDto(400, "Error fetching data", ex.Message, 
                    new List<GetalldonGetAllDonutDto.Out>());
            }

            IActionResult aresult = base.Ok(servansdto);
            return aresult;
        }

        //-------------------------------------------------------------------------------------------------------------
    }
}
