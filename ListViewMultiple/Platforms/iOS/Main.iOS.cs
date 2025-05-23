using UIKit;
using Uno.UI.Hosting;
using ListViewMultiple;

var host = UnoPlatformHostBuilder.Create()
    .App(() => new App())
    .UseAppleUIKit()
    .Build();

host.Run();
