﻿using System.Net.Http;
using System.Threading.Tasks;

namespace WebSite.Services.Abstractions
{
    public interface IHttpClientService
    {
        Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object content = null)
            where TResponse : class;
    }
}
