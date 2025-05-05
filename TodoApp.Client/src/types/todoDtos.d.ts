export interface CreateTodo {
    Title: String;
    Description: String;
    Priority: number | null;
    DueDate: Date | null;
};

export interface UpdateTodo {
    Title: String;
    Description: String;
    IsCompleted: boolean;
    Priority: number | null;
    DueDate: Date | null;
};