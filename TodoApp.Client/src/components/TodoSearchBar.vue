<script setup>
import { useTodoStore } from '@/stores/todoStore'
const todoStore = useTodoStore()
</script>
<template>
  <div class="py-1">
    <input class="w-full p-1 bg-neutral-850 border-2 border-neutral-300 rounded-sm focus-visible:outline-0" 
        type="search" 
        @input="e => todoStore.setFetchQuery(e.target.value)"
    />
  </div>
</template>
