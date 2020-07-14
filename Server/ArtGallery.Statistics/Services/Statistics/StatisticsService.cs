namespace ArtGallery.Statistics.Services.Statistics
{
    using ArtGallery.Common.Servcies;
    using ArtGallery.Statistics.Data;
    using ArtGallery.Statistics.Data.Models;
    using ArtGallery.Statistics.Models.Statistics;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class StatisticsService : DataService<Statistics>, IStatisticsService
    {
        private readonly StatisticsDbContext context;

        private readonly IMapper mapper;

        public StatisticsService(StatisticsDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<StatisticsOutputModel> Full()
        {
            throw new NotImplementedException();
        }

        public async Task AddItem()
        {
            var statistics = await this.All().SingleOrDefaultAsync();

            statistics.TotalItems++;

            await this.Data.SaveChangesAsync();
        }
    }
}
