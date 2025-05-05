<template>
    <div v-if="isOpen" class="fixed inset-0 bg-black bg-opacity-25 flex items-center justify-center z-50">
        <div class="bg-white rounded-lg shadow-xl p-6 w-full max-w-md">
            <div>
                <h2>{{isEdit ? 'Edit Todo' : 'Add New Todo'}}</h2>
                <button @click="closeModal">
                    <CloseIcon />
                </button>
            </div>
            <form @submit.prevent="saveTodo">
                <div class="mb-4">
                    <label for="title" class="block text-sm font-medium text-gray-700 mb-1">Title</label>
                    <input
                        type="text"
                        id="title"
                        v-model="todo.title"
                        placeholder="Enter todo title"
                        required
                    />
                </div>
                <div class="mb-4">
                    <label for="description" class="block text-sm font-medium text-gray-700 mb-1">Title</label>
                    <textarea
                        type="text"
                        id="description"
                        v-model="todo.description"
                        placeholder="Enter todo title"
                        rows="3"
                        required
                    ></textarea>
                </div>
            </form>
        </div>
    </div>
</template>
<script setup>
import CloseIcon from "@/components/icons/CloseIcon.vue"
import { reactive, computed, watch } from 'vue';
import { useTodoStore } from '@/stores/todoStore';

const props = defineProps({
    isOpen: {
        type: Boolean,
        default: false
    },
    editTodo: {
        type: Object,
        default: null
    }
});

const emit = defineEmits(['close', 'saved']);
const todoStore = useTodoStore();

const todo = reactive({
    id: '',
    title: '',
    description: '',
    dueDate: '',
    priority: 'medium',
    completed: false
});

const isEdit = computed(() => !!props.editTodo);

watch(
    () => [props.isOpen, props.editTodo],
    ([newIsOpen, newEditTodo]) => {
        if (newIsOpen && newEditTodo) {
            Object.assign(todo, {
                id: newEditTodo.id,
                title: newEditTodo.title,
                description: newEditTodo.description || '',
                dueDate: newEditTodo.dueDate || '',
                priority: newEditTodo.priority || 'medium',
                completed: newEditTodo.completed || false
            });
        } else if (newIsOpen) {
            Object.assign(todo, {
                id: '',
                title: '',
                description: '',
                dueDate: '',
                priority: 'medium',
                completed: false
            });
        }
    },
    { immediate: true }
);

const closeModal = () => {
    emit('close');
};

const saveTodo = () => {
    if (isEdit.value) {
        todoStore.updateTodo({
            title: todo.title,
            description: todo.description,
            isCompleted: todo.isCompleted,
            priority: todo.priority,
            dueDate: todo.dueDate
        });
    } else {
        todoStore.addTodo({
            title: todo.title,
            description: todo.description,
            priority: todo.priority,
            dueDate: todo.dueDate
        });
    }
    
    emit('saved');
    closeModal();
};

</script>