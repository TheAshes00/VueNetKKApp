import axios from "axios";
const strApiUrl = import.meta.env.VITE_API_URL;

export default{
    //------------------------------------------------------------------------------------
    async strGetLogin(
        objLogin_I
    ){
        let strUrl = strApiUrl + "Login";

        const objApiResponse = await axios.post(strUrl,objLogin_I);

        let strToken = ""
        if(
            objApiResponse.data.intStatus == 200
        ) {
            strToken = objApiResponse.data.objResponse.token;
        }

        return strToken;
    },

    //------------------------------------------------------------------------------------
    async objSetNewUser(
        objNewUser_I
    ){
        let objResponse = null;
        try{
            let strUrl = strApiUrl + "AddUserAuth";

            let objApiResponse = await axios.post(strUrl,objNewUser_I);
            
            objResponse = objApiResponse.data

        }catch(Ex){
            objResponse = {
                intStatus:400, 
                strUserMessage: "Something wrong",
                strDevMessage: "", 
                objResponse: Ex
            };
        }
        return objResponse;
    },

    //----------------------------------------------------------------------------
}