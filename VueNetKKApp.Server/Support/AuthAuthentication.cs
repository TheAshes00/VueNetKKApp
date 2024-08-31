using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.DTO.Auth;
using VueNetKKApp.Server.Models;
using VueNetKKApp.Server.DAO;
using VueNetKKApp.Server.DTO;

namespace VueNetKKApp.Server.Support
{
    public class AuthAuthentication
    {
        //-------------------------------------------------------------------------------------------------------------
        public static bool boolValidateUser(
            DonutsContext context_I, 
            LogLoginDto.In logdtoin_I
            )
        {
            AuthEntity? authentity = AutAuthDao.getUserByUsername(context_I, logdtoin_I.strUsername);

            return (
                authentity != null &&
                BCrypt.Net.BCrypt.Verify(logdtoin_I.strPassword, authentity.strPassword)
                );
        }

        //-------------------------------------------------------------------------------------------------------------
        public static void subSaveNewUser(
            DonutsContext context_M,
            SetnewuseSetNewUserCredential.In setnewuserin_I,
            out ServansdtoServiceAnswerDto servans_O
            )
        {
            //                                              // Manually validate unique username
            AuthEntity? authentity = AutAuthDao.getUserByUsername(context_M, setnewuserin_I.strUsername);

            
            if (
                authentity != null
                ) 
            {
                servans_O = new ServansdtoServiceAnswerDto(
                    400, "Username already taken", "Username most be unique", null);
            }
            else
            {
                //                                              // Add new Authentication info to table
                AuthEntity authentityNew = new();
                authentityNew.strUsername = setnewuserin_I.strUsername;
                authentityNew.strPassword = BCrypt.Net.BCrypt.HashPassword(setnewuserin_I.strPassword);

                AutAuthDao.subAdd(context_M, authentityNew);

                //                                              // Add new User to table
                UserEntity userentity = new();
                userentity.strName = setnewuserin_I.strName;
                userentity.strSurename = setnewuserin_I.strSurename;
                userentity.intPkAuth = authentityNew.intPk;

                UseUserDao.subAdd(context_M, userentity);

                servans_O = new ServansdtoServiceAnswerDto(200, null);
            }
        }

        //-------------------------------------------------------------------------------------------------------------

    }
}
