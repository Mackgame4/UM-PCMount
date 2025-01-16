namespace PCMount.Services;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddLocalServices(this IServiceCollection services)
    {
        services.AddScoped<OrdersService>();
        return services;
    }
}