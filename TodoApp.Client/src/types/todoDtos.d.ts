export interface CreateTodo {
  title: String
  description: String
  priority: number | null
  dueDate: Date | null
}

export interface UpdateTodo {
  title: String
  description: String
  isCompleted: boolean
  priority: number | null
  dueDate: Date | null
}
