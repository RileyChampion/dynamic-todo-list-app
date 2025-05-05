<template>
    <div class="flex flex-1 flex-col">
        <div class="flex flex-row">
            <TodoSearchBar class="flex-1/2" />
            <TodoSwitchProvider class="flex-1" />
        </div>
        <div class="py-2">
            <button @click="openCreateModal" class="w-full p-3 bg-green-600 rounded-md text-lg cursor-pointer hover:bg-green-500">Create Todo</button>
        </div>
        <TodoList @editTodo="openEditModal" />
    </div>
    <TodoModal :isOpen="isModalOpen" :editTodo="currentTodo" @close="closeModal" />
</template>
<script setup lang="ts">
import { ref } from 'vue';
import TodoList from '@/components/TodoList.vue'
import TodoSearchBar from '@/components/TodoSearchBar.vue'
import TodoSwitchProvider from "@/components/TodoSwitchProvider.vue"
import TodoModal from '@/components/TodoModal.vue';
import {Todo} from "@/types/Todo"

const isModalOpen = ref<boolean>(false);
const currentTodo = ref<Todo | null>(null);

const openCreateModal = () => {
  currentTodo.value = null;
  isModalOpen.value = true;
};

const openEditModal = (todo: Todo) => {
  currentTodo.value = todo;
  isModalOpen.value = true;
};

const closeModal = () => {
  isModalOpen.value = false;
  currentTodo.value = null;
};

</script>