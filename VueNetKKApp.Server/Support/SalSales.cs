using Microsoft.EntityFrameworkCore;
using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.DAO;
using VueNetKKApp.Server.DTO;
using VueNetKKApp.Server.DTO.Sales;
using VueNetKKApp.Server.Models;

namespace VueNetKKApp.Server.Support
{
    public class SalSales
    {
        //--------------------------------------------------------------------------------------------------------------
        public static void subRegisterNewSale(
            DonutsContext context_M,
            SetsalSetSaleDto.In setsalesin_I,
            DateTime dateTime_I,
            out ServansdtoServiceAnswerDto servans_O
            )
        {
            servans_O = new(200, null);
            DonutsContext context = new DonutsContext();
            AuthEntity? authentity = AutAuthDao.getUserByUsername(context, setsalesin_I.strUsername);
            int intPkAuth = authentity?.intPk ?? 0;

            if(
                intPkAuth != 0
                )
            {
                SaleEntity saleentity = new SaleEntity();
                saleentity.strName = setsalesin_I.strName;
                saleentity.intQuantity = setsalesin_I.intDonutsBought;
                saleentity.strAddress = setsalesin_I.strAddress;
                saleentity.intPkDonut = setsalesin_I.intPkDonut;
                saleentity.intPkAuth = intPkAuth;
                saleentity.DateSaleDate = dateTime_I;

                SalSalesDao.subAdd(context_M, saleentity);
            }
            else
            {
                servans_O = new(400, "Invalid data", "Username do not exists", null);
            }
            
        }

        //--------------------------------------------------------------------------------------------------------------
        public static void subGetAllSales(
            DonutsContext context_I,
            string strUsername_I,
            bool boolAll,
            out ServansdtoServiceAnswerDto servans_O
            )
        {
            List<GetallsalGetAllSalesDto.Out> darrallsalou;

            if (
                boolAll
                )
            {
                darrallsalou = SalSalesDao.darrAllSales(context_I);
            }
            else
            {
                darrallsalou = SalSalesDao.darrAllSalesByUserName(
                context_I,
                strUsername_I);
            }
            
            servans_O = new(200,darrallsalou);
        }

        //--------------------------------------------------------------------------------------------------------------
        public static void subGetFilteredSales(
            DonutsContext context_I,
            DateTime dateTime_I,
            out ServansdtoServiceAnswerDto servans_O
            )
        {
            List<GetallsalGetAllSalesDto.Out> darrallsalou;

            var filtered = context_I.SaleEntity
                .Where(se => se.DateSaleDate == dateTime_I)
                .Include(k => k.DonutEntity)
                .Include(k => k.AuthEntity)
                .Select( m => new GetallsalGetAllSalesDto.Out
                {
                    intPk= m.intPk,
                    strClientName = m.strName,
                    intQuantity = m.intQuantity,
                    strDonutType = m.DonutEntity.strType,
                    strUserName = m.AuthEntity.strUsername

                }).ToList();
            

            servans_O = new(200, filtered);
        }

        //--------------------------------------------------------------------------------------------------------------

    }
}
