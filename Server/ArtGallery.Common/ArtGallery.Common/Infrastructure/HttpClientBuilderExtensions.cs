﻿namespace ArtGallery.Common.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Net.Http.Headers;
    using Microsoft.AspNetCore.Http;
    using ArtGallery.Services.Identity;

    public static class HttpClientBuilderExtensions
    {
        public static void WithConfiguration(
            this IHttpClientBuilder httpClientBuilder,
            string baseAddress)
            => httpClientBuilder
                .ConfigureHttpClient((serviceProvider, client) =>
                {
                    client.BaseAddress = new Uri(baseAddress);

                    var requestServices = serviceProvider
                        .GetService<IHttpContextAccessor>()
                        ?.HttpContext
                        .RequestServices;

                    var currentToken = requestServices
                        ?.GetService<ICurrentTokenService>()
                        ?.Get();

                    if (currentToken == null)
                    {
                        return;
                    }

                    var authorizationHeader = new AuthenticationHeaderValue(InfrastructureConstants.AuthorizationHeaderValuePrefix, currentToken);
                    client.DefaultRequestHeaders.Authorization = authorizationHeader;
                });
    }
}
