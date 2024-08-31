<template>
    <header>
        <nav>
            <div>
                <a class="navbar-logo" href="https://www.krispykreme.mx/">
                    <img src="../assets/logo.jpg" alt="Krispy Kream">
                </a>
            </div>
            <RouterLink to="/">{{ $route.path != '/' ? 'Home' : 'Welcome' }}</RouterLink >
        </nav>
    </header>
    
</template>

<style scoped>
nav{
    display: flex;
    justify-content: space-between;
    width: 100%;
}
header {
    padding: 16px;
  line-height: 1.5;
  width: 100%;
    /* color: #f2f2f2; */
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
    font-size: 17px;
    display: flex;
    justify-content: flex-end;
}

.navbar-logo{
    width: 70px;
    height: auto;
    display: flex;
    justify-content: center;
    align-items: center;
}
.navbar-logo img{
  display: block;
  width: 100%;
  height: auto;
}

@media (min-width: 1024px) {
  header {
    width: 100%;
    /* color: #f2f2f2; */
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
    font-size: 17px;
    display: flex;
    justify-content: flex-end;
  }
}
</style>