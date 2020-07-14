namespace ArtGallery.Statistics.Services.Statistics
{
    using ArtGallery.Statistics.Models.Statistics;
    using System.Threading.Tasks;

    public interface IStatisticsService 
    {
        Task<StatisticsOutputModel> Full();

        Task AddItem();
    }
}
