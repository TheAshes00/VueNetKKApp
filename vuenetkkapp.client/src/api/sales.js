import router from "@/router";
import axios from "axios";
const strApiUrl = import.meta.env.VITE_API_URL;
const strToken = sessionStorage.getItem("authToken");
const config = {
	headers: {
		Authorization: `Bearer ${strToken}`,
		"Content-Type": "application/json",
	},
};

export default{
    //------------------------------------------------------------------------------------
    async arrGetDonutTypes(
    ) {
        let strUrl = strApiUrl+"Donut/GetAllDonutTypes";
        let arrobjDonut = []
        try{
            let objApiResponse = await axios.get(strUrl,config)
        
            if(
                objApiResponse.data.intStatus == 200
            ){
                arrobjDonut = objApiResponse.data.objResponse
            }
        }catch(Ex){
            alert("Expired sesion")
            router.push("/");
        }
        
        return arrobjDonut
    },

    //------------------------------------------------------------------------------------
    async SetNewSale(
        objSale_I
    ){
        let objApiResponse = await axios.post(strApiUrl+"Sales/AddNewSale",objSale_I,config)
        
        let boolCompleted = false;

        try{
            if(
                objApiResponse.data.intStatus == 200
            ){
                boolCompleted = true
            }
        }catch(Ex){
            alert("Session expired")
            router.push("/");
        }
        
        return boolCompleted
    },

    //------------------------------------------------------------------------------------
    async getAllSales(
        objSend_I
    ){
        let objApiResponse = await axios.get(
            strApiUrl+"Sales/GetAllSales/"+objSend_I.strUsername+"/"+objSend_I.boolAll,
            config)
        
        let arrAllSales = [];

        try{
            if(
                objApiResponse.data.intStatus == 200
            ){
                arrAllSales = objApiResponse.data.objResponse
            }
        }catch(Ex){
            alert("Session expired")
            router.push("/");
        }
        
        return arrAllSales
    },
    
    //------------------------------------------------------------------------------------
}