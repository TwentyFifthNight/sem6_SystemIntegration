using Newtonsoft.Json.Linq;

namespace Server.Services.Data
{
    public interface IDataService
    {
        string? GetPollutionsData(string voivodeship);
        Task<string>? GetIndustriesData(string voivodeship);
    }
}
