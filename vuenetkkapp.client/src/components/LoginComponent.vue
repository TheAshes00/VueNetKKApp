<script>
import { useAuthStore } from '@/store/auth';
import LoaderComponent from './LoaderComponent.vue';

export default{
    setup(){
        const authStore = useAuthStore();
        return { authStore }
    },
    data(){
        return{
            boolIsLoading: false,
            objLogin : {
                strUsername : "",
                strPassword : ""
            }
        }
    },
    components:{
        LoaderComponent
    },
    methods:{
        //--------------------------------------------------------------------------------
        async subLogin(){
            this.boolIsLoading = true;


            await this.authStore.subGetToken(this.objLogin);

            if(
                this.authStore.boolLoginError
            ){
                alert("Invalid user or password")
            }
            else
            {
                this.$router.push("/sales")
            }

            this.boolIsLoading = false;
        },

        //--------------------------------------------------------------------------------
        hideWarningMessage(){
            this.authStore.subShowLoginError(false)
        },

        //--------------------------------------------------------------------------------
    }

}
</script>
<template>
    <div class="container-fluid d-flex justify-content-center">
        <form class="form-attributes " v-on:submit.prevent="subLogin">
            <div class="form-top pb-2">
                <label for="strUsername" class="text-login-color text-login"> 
                    Username
                </label> 
                <input type="text" name="strUsername" id="strUsername" v-model="objLogin.strUsername" required>

                <label for="strPassword">
                    Password 
                </label>
                <input type="password" id="strPassword" name="strPassword" v-model="objLogin.strPassword" required>
            </div>
            <div class="form-bottom pad-8">
                <LoaderComponent v-if="boolIsLoading">
                </LoaderComponent>
                <button class="button login-button shadow-box" type="submit" v-else>
                    Login
                </button>
            </div>
        </form>

    </div>
</template>

<style scoped>
.form-attributes{
    flex-direction: column;
}
</style>