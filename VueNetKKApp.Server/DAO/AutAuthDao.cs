using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.Models;

namespace VueNetKKApp.Server.DAO
{
    public class AutAuthDao
    {
        //-------------------------------------------------------------------------------------------------------------
        public static void subAdd(
            DonutsContext context_M,
            AuthEntity authentity_I
            )
        {
            context_M.AuthEntity.Add(authentity_I);
            context_M.SaveChanges();
        }

        //-------------------------------------------------------------------------------------------------------------
        public static AuthEntity? getUserByUsername(
            DonutsContext context_I,
            string strUsername_I
            )
        {
            return context_I.AuthEntity.FirstOrDefault(a => a.strUsername.Equals(strUsername_I));
        }

        //-------------------------------------------------------------------------------------------------------------
    }
}
