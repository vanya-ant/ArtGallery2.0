﻿using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace ArtGallery.Server.Services.Identity
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get; }
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("Unauthenticated user!");
            }

            this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
