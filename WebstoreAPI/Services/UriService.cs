using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebstoreAPI.Contracts;

namespace WebstoreAPI.Services
{
    public class UriService : IUriService
    {

        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetOrderUri(string orderId)
        {
            return new Uri(_baseUri + ApiRoutes.Orders.GetOrder.Replace("{postId}", orderId));
        }

        public Uri GetUserUri(string userId)
        {
            return new Uri(_baseUri + ApiRoutes.Users.GetUser.Replace("{userId}", userId));
        }

    }
}
