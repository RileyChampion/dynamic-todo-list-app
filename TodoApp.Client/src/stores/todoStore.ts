import { defineStore } from 'pinia';
import APIUtils from "@/utils/todoAPIUtils";
import { debounce } from 'lodash';
import type {Todo} from "@/types/Todo";

interface todoState {
    todos: Todo[],
    query: string,
    provider: string,
    loading: boolean,
    error: string | null,
}

export const useTodoStore = defineStore('todo', {
    state: (): todoState => {
        return {
            todos: [],
            query: '',
            provider: 'basic',
            loading: false,
            error: null
        }
    },
    getters: {
        completedTodos: (state) => state.todos.filter(todo => todo.IsCompleted),
        pendingTodos: (state) => state.todos.filter(todo => !todo.IsCompleted)
    },
    actions: {
        // Fetching Todos with Debounce from Lodash
        setFetchQuery(query: string) {
            this.query = query;
            this.debounceFetchTodos()
        },
        async fetchTodos() {
            try {
                this.loading = true;
                const res = await APIUtils.getTodos(this.provider, this.query);
                this.todos = res.data;
                this.error = null;
            } catch (err: any) {
                this.error = err.message || 'Failed to fetch todos.'
            } finally {
                this.loading = false;
            }
        },
        debounceFetchTodos: debounce(function (this: any) {
            this.fetchTodos()
        }, 500),
    },
});