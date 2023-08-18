namespace OrderManagement.Core.Contracts
{
    public interface IServiceBusService<T>
    {
        Task SendMessageAsync(T messageContent);
    }
}
