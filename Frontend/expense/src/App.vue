<script setup>
    import { RouterView } from 'vue-router';
    import NavBar from './components/NavBar.vue'
</script>

<template>
    <header>
        <div class="row"> 
            <div class="col-xl-2">
                <NavBar/>
            </div>
        </div>
    </header>
    <body>
        <div class="row">
            <div class="col-xl-2">  
                <RouterView />
            </div>
        </div>
    </body>
</template>

<style scoped>

</style>