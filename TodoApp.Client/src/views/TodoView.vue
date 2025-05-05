<script setup lang="ts">
import TodoList from '@/components/TodoList.vue'
import TodoSearchBar from '@/components/TodoSearchBar.vue'
import TodoSwitchProvider from "@/components/TodoSwitchProvider.vue"
</script>

<template>
    <div class="flex flex-row">
        <TodoSearchBar class="flex-1/2" />
        <TodoSwitchProvider class="flex-1" />
    </div>
    <TodoList />
</template>
