namespace ArtGallery.Identity.Services
{
    using ArtGallery.Common.Servcies;
    using ArtGallery.Identity.Data;
    using ArtGallery.Identity.Models;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : DataService<User>, IUserService
    {
        private readonly IMapper mapper;
        public UserService(IdentityDbContext db, IMapper mapper) : base(db)
        {
            this.mapper = mapper;
        }

        public Task<User> FindByUser(string userId)
        {
            return this.FindByUser(userId);
        }

        public async Task<User> FindById(string id)
            => await this.Data.FindAsync<User>(id);

        public async Task<IEnumerable<UserOutputModel>> GetAll()
        {
            return await this.mapper
                .ProjectTo<UserOutputModel>(this.All())
                .ToListAsync();
        }
    }
}
