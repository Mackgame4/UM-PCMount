namespace PCMount.Services;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddOrdersService(this IServiceCollection services) {
        services.AddScoped<OrdersService>();
        return services;
    }
}