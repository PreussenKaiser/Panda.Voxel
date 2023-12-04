using Consul.Bootstrapping;
using Panda.Noise.Visualizer.Extensions;

await ConsoleApplication
	.CreateDefaultBuilder(args)
	.ConfigureServices(services => services
		.AddVisualizer()
		.AddConfiguration(args))
	.Build()
	.RunAsync();
