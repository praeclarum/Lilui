using Microsoft.Extensions.DependencyInjection;

using Lilui;

IServiceCollection services = new ServiceCollection();
services.AddLilui();
var serviceProvider = services.BuildServiceProvider();

var mainThread = serviceProvider.GetRequiredService<IMainThread>();
var window = serviceProvider.GetRequiredService<IWindow>();

mainThread.Run();

