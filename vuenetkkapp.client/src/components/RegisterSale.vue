<script>
import { useSalesStore } from '@/store/sales';
import LoaderComponent from './LoaderComponent.vue';
import { useAuthStore } from '@/store/auth';

export default{
    setup(){
        const salesStore = useSalesStore();
        const authStore = useAuthStore()
        return { salesStore, authStore }
    },
    data(){
        return{
            objNewSale:{
                strName: "",
                strAddress: "",
                strUsername: this.authStore.objUser.strUsername,
                intPkDonut: 0,
                intDonutsBought: 1
            },
            boolIsLoading: false,
        }
    },
    components:{
        LoaderComponent,
    },
    async created(){
        await this.salesStore.subGetDonuts();
    },
    methods:{
        async subNewSale(){
            this.boolIsLoading = true;

            this.objNewSale.intPkAuth = this.authStore.objUser.intPk
            await this.salesStore.subSetNewSale(this.objNewSale);

            if(
                this.salesStore.boolSalesError
            ) {
                alert("Couldn't complete new sale")
            }
            else{
                alert("New sale completed");
                this.objNewSale = {
                    strName: "",
                    strAddress: "",
                    strUsername: this.authStore.objUser.strUsername,
                    intPkDonut: 0,
                    intDonutsBought: 1
                }
            }

            this.boolIsLoading = false

        },
    }
}
</script>

<template>
    <h3 class="pd-8">
        Fill the information:
    </h3>
    <div class="div-top">
        <form class="form-attributes form-register" v-on:submit.prevent="subNewSale">
            <div class="">
                <label for="strUsername">
                    Client name: 
                </label>
                <input type="text" id="strUsername" name="strUsername" v-model="objNewSale.strName" required>

                <label for="strPassword">
                    Client address 
                </label>
                <input type="text" id="strPassword" name="strPassword" v-model.lazy="objNewSale.strAddress" required>
            </div>

            <div class="">
                <label for="donut-type">
                    Donut: 
                </label>
                <select name="donut-type" id="donut-type" v-model.lazy="objNewSale.intPkDonut" required>
                    <option value="" disabled>Choose one... </option>
                    <option v-for="donut in salesStore.arrobjDonutTypes" :key="donut.intPk" :value="donut.intPk">
                        {{ donut.strType }}
                    </option>
                </select>


                <label for="strSurename">
                    Quantity:  
                </label>
                <input class="w-100" type="number" min="1" d="strSurename" name="strSurename" v-model.lazy="objNewSale.intDonutsBought" required>
            </div>
            <div class="button-register" v-if="boolIsLoading">
                <LoaderComponent></LoaderComponent>
            </div>
            <div class="button-register" v-else>
                <button type="submit" class="button shadow-box">Register</button>
            </div>
        </form>
    </div>
</template>


<style scoped>
.form-register{
    flex-direction: column;
    align-items: stretch;
}

.button-register{
    display: flex;
    justify-content: center;
    padding: 16px;
    margin: 8px;
}
.div-top{
    display: flex;
    justify-content: center;
}


</style>