namespace CqrsSample.Services;

public class MessageService : IMessageService
{
    public string GetMessage(string id)
    {
        return $"Hello World: {id}";
    }
}
