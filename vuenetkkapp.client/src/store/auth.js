import auth from '@/api/auth';
import { defineStore } from 'pinia';

export const useAuthStore = defineStore('auth',
    {
        state: () => ({
            objUser: null,
            boolLoginError: false,
            boolShowLoginError: false,
            objNewUser: null,
            boolNewUserError: false,
            boolShowNewUserError: false,
        }),
        getters: {

        },
        actions: {
            //----------------------------------------------------------------------------
            async subGetToken(
                objLogin_I
            ) {
                let strTokenResponse = await auth.strGetLogin(objLogin_I);
                if(
                    strTokenResponse === ""
                ){
                    this.boolLoginError = true;
                    this.boolShowLoginError = true;
                }
                else
                {
                    this.boolLoginError = false;
                    this.boolShowLoginError = false;
                    this.objUser = objLogin_I;
                    sessionStorage.setItem('authToken', strTokenResponse);
                }
            },

            //----------------------------------------------------------------------------
            subShowLoginError(
                boolShowLoginError_I
            ){
                this.boolShowLoginError = boolShowLoginError_I;
            },

            //----------------------------------------------------------------------------
            async subNewUser(
                objNewUser_I
            ){
                let objApiResponse = await auth.objSetNewUser(objNewUser_I);
                if(
                    objApiResponse.intStatus == 200
                ) {
                    this.boolNewUserError = false;
                    this.boolShowNewUserError = false ;
                }
                else
                {
                    this.boolNewUserError = true;
                    this.boolShowNewUserError = true ;
                    this.objNewUser = objApiResponse;
                }
            },

            //----------------------------------------------------------------------------
            subShowNewUserError(
                boolShowNewUserError_I
            ){
                this.boolShowNewUserError = boolShowNewUserError_I;
            },

            //----------------------------------------------------------------------------
        }
    }
);