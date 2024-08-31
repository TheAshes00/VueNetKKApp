<script>
import LoaderComponent from '@/components/LoaderComponent.vue';
import { useAuthStore } from '@/store/auth';

export default{
    setup(){
        const authStore = useAuthStore()
        return { authStore }
    },
    data(){
        return {
            objRegister: {
                strUsername: "",
                strPassword: "",
                strName: "",
                strSurename: "",
            },
            boolIsLoading: false,
        }
    },
    components:{
        LoaderComponent
    },
    methods:{
        //--------------------------------------------------------------------------------
        async subSetNewUser(){
            this.boolIsLoading = true;

            await this.authStore.subNewUser(this.objRegister)
            if(
                !this.authStore.boolNewUserError
            ){
                alert('User saved')
                this.$router.push('/');
            }
            else
            {
                alert(this.authStore.objNewUser.strUserMessage)
            }
            this.boolIsLoading = false;
        },

        //--------------------------------------------------------------------------------
    },
}
</script>
<template>
    <h2>
        Register
    </h2>
    <h3>Fill the following information:</h3>
    <div>
        <form class="form-attributes form-register" v-on:submit.prevent="subSetNewUser">
            <div class="">
                <label for="strUsername">
                    Username: 
                </label>
                <input type="text" id="strUsername" name="strUsername" v-model="objRegister.strUsername" required>

                <label for="strPassword">
                    Password 
                </label>
                <input type="password" id="strPassword" name="strPassword" v-model.lazy="objRegister.strPassword" required>
            </div>

            <div class="">
                <label for="strName">
                    Name: 
                </label>
                <input type="text" id="strName" name="strName" v-model.lazy="objRegister.strName" required>

                <label for="strSurename">
                    Surename:  
                </label>
                <input type="text" id="strSurename" name="strSurename" v-model.lazy="objRegister.strSurename" required>
            </div>
            <div class="button-register" v-if="boolIsLoading">
                <LoaderComponent></LoaderComponent>
            </div>
            <div class="button-register" v-else>
                <button type="submit" class="shadow-box">Register</button>
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
</style>