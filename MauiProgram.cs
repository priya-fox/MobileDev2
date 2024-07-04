using Microsoft.Extensions.Logging;

namespace StaffDirectory;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			
				fonts.AddFont("Trebuchet-MS.ttf", "Trebuschet"));
				
// # if
		builder.Logging.AddDebug();
//#endif

		return builder.Build();
	}
}
