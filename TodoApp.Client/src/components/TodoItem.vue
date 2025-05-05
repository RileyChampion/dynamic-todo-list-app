<script setup lang="ts">
import { useTodoStore } from '@/stores/todoStore';
import { Todo } from "@/types/Todo.d.ts"
import EditIcon from "@/components/icons/EditIcon.vue"
import DeleteIcon from "@/components/icons/DeleteIcon.vue"

const todoStore = useTodoStore();

defineProps<{
    todoItem: Todo
}>()
</script>

<template>
    <tr>
        <td class="py-1.5 border-b-1"><input 
                type="checkbox" 
                v-model="todoItem.isCompleted"
                @click="todoStore.toggleCompleteStatus(todoItem.id, {
                    title: todoItem.title,
                    description: todoItem.description,
                    isCompleted: !todoItem.isCompleted,
                    priority: todoItem.priority,
                    dueDate: todoItem.dueDate
                })"
            />
        </td>
        <td class="py-1.5 border-b-1">{{todoItem.title}}</td>
        <td class="py-1.5 border-b-1">{{todoItem.description}}</td>
        <td class="py-1.5 border-b-1">{{todoItem.createdAt}}</td>
        <td class="py-1.5 border-b-1"><button class=" bg-yellow-500  text-black rounded-sm p-0.5 cursor-pointer hover:bg-amber-300  transition-colors"><EditIcon /></button></td>
        <td class="py-1.5 border-b-1"><button class="  bg-red-600  text-black rounded-sm p-0.5 cursor-pointer hover:bg-red-400  transition-colors"><DeleteIcon /></button></td>
    </tr>
</template>