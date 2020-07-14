namespace ArtGallery.Statistics.Models
{
    using ArtGallery.Common.Messages.Items;
    using ArtGallery.Statistics.Services.Statistics;
    using MassTransit;
    using System.Threading.Tasks;

    public class ItemCreatedConsumer : IConsumer<ItemCreatedMessage>
    {
        private readonly IStatisticsService statisticsService;
        public async Task Consume(ConsumeContext<ItemCreatedMessage> context)
        {
            var message = context.Message;

            await this.statisticsService.AddItem();
        }
    }
}
