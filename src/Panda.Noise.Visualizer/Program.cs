using Consul.Bootstrapping;
using Panda.Noise.Visualizer.Extensions;
using Panda.Noise.Visualizer.Implementations;

await ConsoleApplication
	.CreateDefaultBuilder(args)
	.ConfigureServices(services => services
		.AddVisualizer<GrayScaleColorPicker>(args)
		.AddRandomNoise())
	.Build()
	.RunAsync();
