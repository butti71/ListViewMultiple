namespace ListViewMultiple.Services.Caching;
using WeatherForecast = ListViewMultiple.DataContracts.WeatherForecast;
public interface IWeatherCache
{
    ValueTask<IImmutableList<WeatherForecast>> GetForecast(CancellationToken token);
}
