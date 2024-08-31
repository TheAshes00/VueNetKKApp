<script>
import RegisterSale from '@/components/RegisterSale.vue';
import SalesComponent from '@/components/SalesComponent.vue';

export default{
    components: {
        RegisterSale,
        SalesComponent,
    },
    data(){
        return {
            strActionSelected : "",
        }
    }
}
</script>
<template>
    <div class="register-options">
      <div class="form-check">
        <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1"
          value="donut-sale" v-model="strActionSelected">
        <label class="form-check-label" for="flexRadioDefault1">
          Donut Sale
        </label>
      </div>
      <div class="form-check">
        <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2"
          value="view-sales" v-model="strActionSelected">
        <label class="form-check-label" for="flexRadioDefault2">
          View Sales Per User
        </label>
      </div>

      <div class="form-check">
        <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault3"
          value="view-all" v-model="strActionSelected">
        <label class="form-check-label" for="flexRadioDefault3">
          View All Sales
        </label>
      </div>
    </div>
    
    <Transition>
      <div v-if="strActionSelected === 'donut-sale'">
        <RegisterSale></RegisterSale>
      </div>
    </Transition>
    <Transition>
      <div v-if="strActionSelected === 'view-sales' || strActionSelected === 'view-all'">
          <SalesComponent :strParent="strActionSelected"></SalesComponent>
      </div>
    </Transition>

</template>

<style scoped>
.v-enter-active,
.v-leave-active {
  transition: opacity 0.5s ease;
}

.v-enter-from,
.v-leave-to {
  opacity: 0;
}

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