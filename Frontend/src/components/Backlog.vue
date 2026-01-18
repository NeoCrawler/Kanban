<template>
    <div class="flex-0 h-full bg-gray-500 border rounded-sm">
        <div class="flex w-full h-10 bg-gray-100">
            <input id="task" type="text" v-model="taskName" placeholder="Enter task name" 
            class="h-full border border-gray-300 rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400"/>
            
            <button class="w-full h-full text-black p-1 rounded hover:bg-blue-600 transition" @click="createTask">
                <slot>New</slot>
            </button>
        </div>

        <div>
            <ul>
                <li v-for="task in tasks" :key="task.guid">
                    <Task :task="task" @update="handleUpdate" />
                </li>
            </ul>
        </div>

    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { RemoteTask } from '../data/RemoteTask';

import Label from './Label.vue';
import Task from './Task.vue';



const taskName = ref('')
const tasks = ref<RemoteTask[]>([]);
const responseMessage = ref('')

async function createTask()
{
    try
    {
        const response = await fetch('https://localhost:7033/api/Task/Create', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify
        (
            { 
                name: taskName.value, 
                description: "",
                labelId: ""
            }
        )})

        if (!response.ok) throw new Error('Request failed')

        const data = await response.json()
        responseMessage.value = `Task added with ID: ${data.guid}`
        console.log(responseMessage.value)
        await fetchPosts();

    }
    catch (error) {
    console.error(error)
    responseMessage.value = 'Failed to add task'
    }
}

async function fetchPosts() 
{
    try 
    {
        const response = await fetch('https://localhost:7033/api/Task/GetAll');
        
        if (!response.ok) throw new Error('Network response was not ok');
        
        const preData = await response.json();
        const data: RemoteTask[] = preData;
        tasks.value = data
    } catch (error) 
    {
        console.error('Fetch error:', error);
    }
}

async function handleUpdate() 
{
    await null;
}

onMounted(() => {
   fetchPosts();
});

</script>