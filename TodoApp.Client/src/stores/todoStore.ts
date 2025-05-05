import { defineStore } from 'pinia'
import APIUtils from '@/utils/todoAPIUtils'
import { debounce } from 'lodash'
import type { Todo } from '@/types/Todo'
import type { CreateTodo, UpdateTodo } from '@/types/todoDtos'
import { Provider } from '@/types/Provider.d.ts'

interface todoState {
  todos: Todo[]
  query: string
  provider: Provider
  loading: boolean
  error: string | null
}

export const useTodoStore = defineStore('todo', {
  state: (): todoState => {
    return {
      todos: [],
      query: '',
      provider: Provider.BASIC,
      loading: false,
      error: null,
    }
  },
  getters: {
    completedTodos: (state) => state.todos.filter((todo) => todo.isCompleted),
    pendingTodos: (state) => state.todos.filter((todo) => !todo.isCompleted),
  },
  actions: {
    // Set Query
    setFetchQuery(query: string) {
      this.query = query
      this.debounceFetchTodos()
    },
    // Set Provider
    setProvider(value: Provider) {
      this.provider = value
    },
    // Fetching Todos with Debounce from Lodash
    async fetchTodos() {
      try {
        this.loading = true
        const res = await APIUtils.getTodos(this.provider, this.query)
        this.todos = res.data
        this.error = null
      } catch (err: any) {
        this.error = err.message || 'Failed to fetch todos.'
      } finally {
        this.loading = false
      }
    },
    debounceFetchTodos: debounce(function (this: any) {
      this.fetchTodos()
    }, 500),
    async fetchTodo(todoId: number) {
      // Fetch specific Todo from API
      try {
        this.loading = true
        const res = await APIUtils.getTodo(this.provider, todoId)
        this.error = null
      } catch (err: any) {
        this.error = err.message || 'Failed to fetch todo.'
      } finally {
        this.loading = false
      }
    },
    async createTodo(createdTodo: CreateTodo) {
      // Creates a new Todo
      try {
        this.loading = true
        const res = await APIUtils.createTodo(this.provider, createdTodo)
        this.todos.push(res.data)
        this.error = null
      } catch (err: any) {
        this.error = 'Failed to add todo.'
      } finally {
        this.loading = false
      }
    },
    async updateTodo(todoId: number, updatedTodo: UpdateTodo) {
      // Updates given todo
      try {
        this.loading = true
        const res = await APIUtils.updateTodo(this.provider, todoId, updatedTodo)
        const index = this.todos.findIndex((t) => t.Id === res.data.Id)
        if (index !== -1) {
          this.todos[index] = res.data
        }
        this.error = null
      } catch (err: any) {
        this.error = 'Failed to update todo.'
      } finally {
        this.loading = false
      }
    },
    async deleteTodo(todoId: number) {
      // Delete given todoId
      try {
        this.loading = true
        const res = await APIUtils.deleteTodo(this.provider, todoId)
        const index = this.todos.findIndex((t) => t.Id === res.data.Id)
        if (index !== -1) {
          this.todos[index] = res.data
        }
        this.error = null
      } catch (err: any) {
        this.error = 'Failed to delete todo.'
      } finally {
        this.loading = false
      }
    },
    async toggleCompleteStatus(todoId: number, updatedTodo: UpdateTodo) {
      // Toggle Complete Check
      try {
        this.loading = true
        const res = await APIUtils.updateTodo(this.provider, todoId, updatedTodo)
        const index = this.todos.findIndex((t) => t.id === res.data.id)
        if (index !== -1) {
          this.todos[index] = res.data
        }
        this.error = null
      } catch (err: any) {
        this.error = 'Failed to toggle todo complete.'
      } finally {
        this.loading = false
      }
    },
  },
})
