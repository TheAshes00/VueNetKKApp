using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.Models;

namespace VueNetKKApp.Server.DAO
{
    public class UseUserDao
    {
        public static void subAdd(
            DonutsContext context_I, 
            UserEntity useentity_I
            )
        {
            context_I.UserEntity.Add(useentity_I);
            context_I.SaveChanges();
        }
    }
}
