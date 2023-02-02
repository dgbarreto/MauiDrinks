using DrinksApp.View;
using DrinksApp.Services;
using DrinksApp.ViewModel;

namespace DrinksApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<DrinkService>();
		builder.Services.AddSingleton<DrinksViewModel>();
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
