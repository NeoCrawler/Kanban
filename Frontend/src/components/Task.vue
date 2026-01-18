<template>
  <div class="task-item">
    <input v-model="localTask.name" />
    <input v-model="localTask.description" />

    <button @click="emitUpdate">Save</button>
  </div>
</template>

<script setup>
import { reactive, watch } from 'vue'

// Reactive object, representing the data passed from the parent.
// A child does not have a type definition.
// In theory, each child could have a unique data set.
const props = defineProps({
  task: {
    type: Object,
    required: true
  }
})

// Callback event for the parent.
// For the parent to assign itself to this event: <TaskCard :task="task" @update="handleUpdate" />
const emit = defineEmits(['update'])

// Local copy so we don't mutate props directly
const localTask = reactive({ ...props.task })

// Keep local copy in sync if parent changes
watch(
  () => props.task,
  (newTask) => {
    Object.assign(localTask, newTask)
  }
)

function emitUpdate() {
  emit('update', { ...localTask })
}
</script>