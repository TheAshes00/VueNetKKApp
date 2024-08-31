using Microsoft.AspNetCore.Mvc;
using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.DTO.Sales;
using VueNetKKApp.Server.DTO;
using VueNetKKApp.Server.Support;
using Microsoft.AspNetCore.Authorization;

namespace VueNetKKApp.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        //--------------------------------------------------------------------------------------------------------------
        //                                          INSTANCE VARIABLES
        //--------------------------------------------------------------------------------------------------------------
        private readonly ILogger<SalesController> _logger;
        private IConfiguration _configuration;

        //-------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTORS.
        public SalesController(ILogger<SalesController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            _configuration = iConfig;
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public IActionResult AddNewSale(
            [FromBody]
            SetsalSetSaleDto.In setsalesin
        )
        {
            /*
             
             {
"strName": "Harvey Specter",
"strAddress": "Harlem Lake, 23456, Chicago" ,
"intPkDonut": 7,
"intDonutsBought": 24,
"intPkAuth": 1
}
             */
            ServansdtoServiceAnswerDto servansdto;
            using var context = new DonutsContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                if (
                    !ModelState.IsValid
                    )
                {
                    servansdto = new(400,"Invalid data","Invalid data model", null);
                }
                else
                {
                    SalSales.subRegisterNewSale(context, setsalesin, out servansdto);
                    transaction.Commit();
                }
            }
            catch (
                Exception ex
            )
            {
                servansdto = new ServansdtoServiceAnswerDto(400, "Error while saving new order", ex.Message, null);
                transaction.Rollback();
            }

            IActionResult aresult = base.Ok(servansdto);
            return aresult;
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]/{strUsername}/{boolAll}")]
        public IActionResult GetAllSales(
            [FromRoute]
            string strUsername,
            bool boolAll
        )
        {
            ServansdtoServiceAnswerDto servansdto;
            using var context = new DonutsContext();

            try
            {
                SalSales.subGetAllSales(context, strUsername, boolAll,out servansdto);
            }
            catch (
                Exception ex
            )
            {
                servansdto = new ServansdtoServiceAnswerDto(400, "Error fetching data", ex.Message, null);
            }

            IActionResult aresult = base.Ok(servansdto);
            return aresult;
        }
        //--------------------------------------------------------------------------------------------------------------
    }
}
