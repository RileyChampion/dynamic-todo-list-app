import axios from 'axios'
import type { CreateTodo, UpdateTodo } from '@/types/todoDtos'

const apiClient = axios.create({
  baseURL: 'http://localhost:5160/api',
  headers: {
    'Content-Type': 'application/json',
  },
})

export default {
  getTodos(provider: String, searchQuery: String = '') {
    return apiClient.get(
      `/Todos?provider=${provider}${searchQuery != '' ? `&searchQuery=${searchQuery}` : ''}`,
    )
  },
  getTodo(provider: String, todoId: number) {
    return apiClient.get(`/Todos/${todoId}?provider=${provider}`)
  },
  createTodo(provider: String, cTodo: CreateTodo) {
    return apiClient.post(`/Todos?provider=${provider}`, cTodo)
  },
  updateTodo(provider: String, todoId: number, uTodo: UpdateTodo) {
    return apiClient.put(`/Todos/${todoId}?provider=${provider}`, uTodo)
  },
  deleteTodo(provider: String, todoId: number) {
    return apiClient.delete(`/Todos/${todoId}?provider=${provider}`)
  },
}
