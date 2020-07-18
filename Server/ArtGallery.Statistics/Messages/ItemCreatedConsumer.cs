namespace ArtGallery.Statistics.Messages
{
    using ArtGallery.Common.Messages.Items;
    using ArtGallery.Statistics.Services.Statistics;
    using MassTransit;
    using System.Threading.Tasks;

    public class ItemCreatedConsumer : IConsumer<ItemCreatedMessage>
    {
        private readonly IStatisticsService statisticsService;

        public ItemCreatedConsumer(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        public async Task Consume(ConsumeContext<ItemCreatedMessage> context)
        {
            var message = context.Message;

            await this.statisticsService.AddItem();
        }
    }
}
