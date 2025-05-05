<template>
    <div class="flex-1 overflow-auto">
        <table class="w-full text-left">
            <thead class="!font-bold">
                <tr>
                    <th class="py-1.5 !font-bold"></th>
                    <th class="py-1.5 border-b-1">Title</th>
                    <th class="py-1.5 border-b-1">Description</th>
                    <th class="py-1.5 border-b-1">Created At</th>
                    <th class="py-1.5 border-b-1">Edit</th>
                    <th class="py-1.5 border-b-1">Delete</th>
                </tr>
            </thead>
            <tbody>
                <TodoItem 
                    v-for="todo in todoStore.todos" 
                    :todoItem="todo"
                    @edit="editTodo"
                />
            </tbody>
        </table>
    </div>
</template>
<script setup lang="ts">
import { onMounted } from 'vue';
import { useTodoStore } from '@/stores/todoStore';
import { Todo } from "@/types/Todo";
import TodoItem from '@/components/TodoItem.vue';

const todoStore = useTodoStore();

onMounted(() => {
    todoStore.fetchTodos();
});

const emit = defineEmits(['editTodo', 'deleteTodo']);
const editTodo = (todo : Todo) => {
    emit('editTodo', todo);
}
</script>