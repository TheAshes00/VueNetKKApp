using Microsoft.EntityFrameworkCore;
using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.DTO.Sales;
using VueNetKKApp.Server.Models;

namespace VueNetKKApp.Server.DAO
{
    public class SalSalesDao
    {
        //--------------------------------------------------------------------------------------------------------------
        public static List<GetallsalGetAllSalesDto.Out> darrAllSales(
            DonutsContext context_I)
        {
            var query = from s in context_I.SaleEntity
                        join a in context_I.AuthEntity on s.intPkAuth equals a.intPk
                        join d in context_I.DonutEnity on s.intPkDonut equals d.intPk
                        join u in context_I.UserEntity on a.intPk equals u.intPkAuth
                        select new GetallsalGetAllSalesDto.Out
                        {
                            strClientName = s.strName,
                            strDonutType = d.strType,
                            strUserName = u.strName + " " + u.strSurename,
                            intQuantity = s.intQuantity,
                            intPk = s.intPk
                        };

            var result = query.ToList();
            return result;
        }

        //--------------------------------------------------------------------------------------------------------------
        public static void subAdd(
            DonutsContext context_I, 
            SaleEntity salentity_I
            )
        {
            context_I.SaleEntity.Add(salentity_I);
            context_I.SaveChanges();
        }

        //--------------------------------------------------------------------------------------------------------------
        public static List<GetallsalGetAllSalesDto.Out> darrAllSalesByUserName(
            DonutsContext context_I,
            string strUserName_I
            )
        {
            var query = from s in context_I.SaleEntity
                        join a in context_I.AuthEntity on s.intPkAuth equals a.intPk
                        join d in context_I.DonutEnity on s.intPkDonut equals d.intPk
                        join u in context_I.UserEntity on a.intPk equals u.intPkAuth
                        where a.strUsername == strUserName_I
                        select new GetallsalGetAllSalesDto.Out
                        {
                            strClientName = s.strName,
                            strDonutType = d.strType,
                            strUserName = u.strName + " " + u.strSurename,
                            intQuantity = s.intQuantity,
                            intPk = s.intPk
                        };

            var result = query.ToList();
            return result;
        }


        //--------------------------------------------------------------------------------------------------------------
    }
}
