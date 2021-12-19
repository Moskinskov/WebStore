namespace WebStore.Infrastructure.Middleware;

public class TestMiddleware
{
    private readonly RequestDelegate next;

    public TestMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Обработка информации из context.Request
        
        Task processing = next(context); // здесь работает оставшаяся часть конвеера
        
        // Выполняем какие-то действия параллельно\ассинхронно с остальной частью конвеера
        
        await processing;
        
        // доработка данных в context.Response
    }
}