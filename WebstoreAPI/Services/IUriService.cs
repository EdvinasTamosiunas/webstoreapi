using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebstoreAPI.Services
{
    public interface IUriService
    {
        Uri GetOrderUri(string orderId);
        Uri GetUserUri(string userId);
    }
}
