<script>
import HeaderComponent from './components/HeaderComponent.vue';

export default{
  components:{
    HeaderComponent
  }
}

</script>

<template>
  <HeaderComponent></HeaderComponent>
    <main>
      <RouterView></RouterView>
    </main>
</template>

<style scoped>
header {
  line-height: 1.5;
  padding: 5px;
  margin: 10px;
  background: radial-gradient(#211d1d05, #cae5ca);
  border-radius: 10px;
  margin-bottom: 36px;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
