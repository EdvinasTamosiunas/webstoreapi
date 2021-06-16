using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;

namespace WebstoreAPI.Services
{
    public interface IPaymentService
    {

        public Task<Payment> CompletePayment(string paymentId);

        public Task<Payment> PostPaymentToDb(PaymentRequest paymentRequest);

        public Task<Payment> MarkPaymentAsRefunded(string paymentId);
    }
}