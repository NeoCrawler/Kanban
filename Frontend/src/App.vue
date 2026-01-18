<script setup lang="ts">
import { onMounted } from 'vue'
import HelloWorld from './components/HelloWorld.vue'

async function TestConnection()
{
    try 
    {
        const response = await fetch('https://localhost:7033/api/Task/GetAll');
        
        if (!response.ok) throw new Error('Network response was not ok');
        
        const data = await response.json();
        console.log(data);

    } catch (error) 
    {
        console.error('Fetch error:', error);
    }
}

onMounted(() =>
{
  TestConnection();
})

</script>

<template>
  <div>
    <a href="https://vite.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo" />
    </a>
    <a href="https://vuejs.org/" target="_blank">
      <img src="./assets/vue.svg" class="logo vue" alt="Vue logo" />
    </a>
  </div>
  <HelloWorld msg="Vite + Vue" />
</template>

<style scoped>

</style>
