type Todo = {
  id: number
  title: String
  description: String
  isCompleted: boolean
  completedAt: Date | null
  createdAt: Date
  updatedAt: Date
  priority: number | null
  dueDate: Date | null
}

export { Todo }
