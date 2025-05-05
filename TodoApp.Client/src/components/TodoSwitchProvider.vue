<script setup>
import { useTodoStore } from '@/stores/todoStore'
const todoStore = useTodoStore()
</script>
<template>
    <div class="py-1 pl-2">
        <select 
            class="w-full h-full border-2 border-neutral-200 rounded-sm"
            :value="todoStore.provider"
            @input="e => todoStore.setProvider(e.target.value)"
        >
            <option value="basic">Basic</option>
            <option value="advanced">Advanced</option>
        </select>
    </div>
</template>
<script>

</script>