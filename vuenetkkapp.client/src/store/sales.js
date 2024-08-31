import sales from '@/api/sales';
import { defineStore } from 'pinia';

export const useSalesStore = defineStore('sales',
    {
        state: () => ({
            arrobjDonutTypes: [],
            arrobjSales: [],
            boolSalesError: false,
        }),
        getters: {

        },
        actions: {
            //----------------------------------------------------------------------------
            async subGetDonuts(
            ) {
                let objApiResponse = await sales.arrGetDonutTypes();

                this.arrobjDonutTypes = objApiResponse;
            },

            //----------------------------------------------------------------------------
            async subSetNewSale(
                objNewSale_I
            ){
                let objApiResponse = await sales.SetNewSale(objNewSale_I);
                if(
                    objApiResponse == true
                ) {
                    this.boolSalesError = false;
                }
                else
                {
                    this.boolSalesError = true;
                }
            },

            //----------------------------------------------------------------------------
            async getAllSales(
                objSend_I
            ){
                let objApiResponse = await sales.getAllSales(objSend_I);
                this.arrobjSales = objApiResponse;
            },

            //----------------------------------------------------------------------------
        }
    }
);