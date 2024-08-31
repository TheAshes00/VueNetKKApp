<script>
import LoginComponent from '@/components/LoginComponent.vue';

export default{
    components: {
        LoginComponent,
    },
    data(){
        return{
            
        }
    },

};
</script>
<template>
    <LoginComponent/>
    <div class="link">
        <RouterLink to="/register" class="shadow-box">Sign In</RouterLink>
    </div>
</template>

<style scoped>
    .link {
        display: flex;
        justify-content: center;
        padding: 0px 16px;
        margin: 16px 26px;
    }

    a {
        border-radius: 5px;
        color: #c7ffc2;
        background: radial-gradient(black, rgb(9 9 9 / 47%));
        padding: 8px 16px;
    }
</style>