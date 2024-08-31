<script>
import { useAuthStore } from '@/store/auth';
import { useSalesStore } from '@/store/sales';

export default{
    props:["strParent"],
    setup(){
        const salesStore = useSalesStore();
        const authStore = useAuthStore();
        return { salesStore,authStore }
    },
    data(){
        return{
            arrobjAllSales: [],
            intIdentifier: 0,
        }
    },
    async created(){
        let objSend = {
            strUsername: this.authStore.objUser.strUsername,
            boolAll: false
        }
        if(
            this.strParent === "view-sales"
        ) {
            await this.salesStore.getAllSales(objSend)
        }
        else
        {
            objSend.boolAll=true;
            await this.salesStore.getAllSales(objSend)
        }
        this.arrobjAllSales = this.salesStore.arrobjSales
    },
    methods:{
        filterArray(
            boolReset
        ){
            if(
                boolReset
            ) {
                this.arrobjAllSales = this.salesStore.arrobjSales
            }
            else{
                let arrFilteredArray = this.arrobjAllSales.filter( 
                    obj => obj.intPk == this.intIdentifier)
                this.arrobjAllSales = arrFilteredArray  
            }
        },

        //--------------------------------------------------------------------------------
        
    }
}
</script>

<template>
    <h3>
        Sales per user
    </h3>

    <form v-on:submit.prevent="filterArray(false)">
        <div class="search-button-container" v-if="strParent != 'view-sales'">
            <div class="input-text">
                <input type="number" name="search-in" id="search-in" v-model="intIdentifier" required>
            </div>
            
            <div class="">
                <button type="submit" class=" hg3 button-align-text search-button">Search</button>
            </div>

            <div class="">
                <button type="button" class="cancel hg3 button-align-text cancel-button" v-on:click="filterArray(true)">Cancel</button>
            </div>
        </div>
    </form>
    <div class="table-container" id="sales-list">
        <table class="table">
            <thead>
                <tr>
                    <th>
                        ID
                    </th>
                    <th>
                        Client Name 
                    </th>
                    <th>
                        DonutType
                    </th>
                    <th>
                        Donuts Sold
                    </th>
                    <th>
                        User Name
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="objSale in arrobjAllSales" :key="objSale.intPk">
                    <th>
                        {{ objSale.intPk }}
                    </th>
                    <th>
                        {{  objSale.strClientName  }}
                    </th>
                    <th>
                        {{ objSale.strDonutType }}
                    </th>
                    <th>
                        {{  objSale.intQuantity   }}
                    </th>
                    <th>
                        {{ objSale.strUserName }}
                    </th>
                </tr>
            </tbody>
        </table>
    </div>
</template>


<style>
.table{
    color: #493939;
    max-width: 650px;
    background: #0000000f;
    border-radius: 10px;
}
thead{
    font-weight: 600;
    color: #6cc091;
}
.table-container{
    display: flex;
    justify-content: center;
}

/* width */
::-webkit-scrollbar {
    width: 12px;
    border-radius: 3px;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
    background: #cdcdcd;
}

#sales-list {
    overflow-y: auto;
    max-height: 380px;
    overflow-x: hidden;
}

.search-button-container{
    display: flex;
    justify-content: center;
    padding: 8px;
    gap: 5px;
    align-items: center;
}

.hg3{
    height: 3em;
}

.button-align-text{
    display: flex;
    align-items: center;
}

.search-button{
    background: #19875454
}

.cancel-button{
    background: #ef6161;
}
</style>