using TodoApp.API.Data;

public class TodoFeatureFactory {
    private readonly TodoAppDbContext _context;

    public TodoFeatureFactory(TodoAppDbContext context){
        _context = context;
    }

    public ITodoFeatureProvider CreateProvider(string providerType){
        return providerType.ToLower() switch 
        {
            "advanced" => new AdvancedTodoFeatureProvider(_context),
            _ => new BasicTodoFeatureProvider(_context)
        };
    }
}