using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebstoreAPI.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public static class Items
        {
            public const string GetAll = Root + "/items";

            public const string GetPicture = Root + "/items/picture/{itemId}";

            public const string UpdateItem = Root + "/items/update/{itemId}";
        }

        public static class Orders
        {
            public const string GetAll = Root + "/orders";
            
            public const string GetOrder = Root + "/orders/{orderId}";

            public const string PostOrder = Root + "/orders/post";

        }

        public static class Payments
        {
            public const string CompletePayment = Root + "/payments/complete/{paymentId}";

            public const string RefundPayment = Root + "/payments/refund/{paymentId}";

        }

        public static class Users
        {
            public const string Login = Root + "/users/login";

            public const string GetAll = Root + "/users";
            
            public const string GetUser = Root + "user/{userId}";

            public const string UpdateUser = Root + "/users/update/{itemId}";

            public const string AddUser = Root + "/users/add";
        }
    }
}
