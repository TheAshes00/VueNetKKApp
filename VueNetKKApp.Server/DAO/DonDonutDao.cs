using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.Models;

namespace VueNetKKApp.Server.DAO
{
    public class DonDonutDao
    {
        public static List<DonutEntity> darrGet(
            DonutsContext context_I
            ) 
        {
            return context_I.DonutEnity.ToList();

        }
    }
}
