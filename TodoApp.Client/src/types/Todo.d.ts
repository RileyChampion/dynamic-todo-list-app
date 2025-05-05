type Todo = {
    Id: number;
    Title: String;
    Description: String;
    IsCompleted: boolean;
    CompletedAt: Date | null;
    CreatedAt: Date;
    UpdatedAt: Date;
    Priority: number | null;
    DueDate: Date | null;
};

export { Todo };