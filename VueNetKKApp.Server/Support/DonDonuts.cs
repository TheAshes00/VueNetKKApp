using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.DAO;
using VueNetKKApp.Server.DTO.Donut;
using VueNetKKApp.Server.Models;

namespace VueNetKKApp.Server.Support
{
    public class DonDonuts
    {
        //-------------------------------------------------------------------------------------------------------------
        public static List<GetalldonGetAllDonutDto.Out> arrGetAllDonuts(
            DonutsContext context_I
            )
        {
            List<DonutEntity> darrdon = DonDonutDao.darrGet(context_I);

            return darrdon.Select(d => new GetalldonGetAllDonutDto.Out
                {
                    intPk = d.intPk,
                    strType = d.strType
                }).ToList();
        }

        //-------------------------------------------------------------------------------------------------------------
    }
}
