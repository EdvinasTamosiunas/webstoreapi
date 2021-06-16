using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace WebstoreAPI.Services
{
    public class PaymentService : IPaymentService
    {
        //TODO add validations
        private readonly DatabaseContext _context;

        public PaymentService(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Payment>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetPaymentById(string id)
        {
            return await _context
                .Payments
                .SingleOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<Payment> CompletePayment(string id)
        {
            var payment = _context
                .Payments
                .FirstOrDefault(entity => entity.Id == id);

            if (payment == null) return null;
            payment.Pending = false;
            _context.Update(payment);
            await _context.SaveChangesAsync();
            return payment;

        }

        public async Task<Payment> PostPaymentToDb(PaymentRequest paymentRequest)
        {
            var newPayment = new Payment(paymentRequest);
            _context.Add(newPayment);
            await _context.SaveChangesAsync();
            return newPayment;
        }

        public async Task<Payment> MarkPaymentAsRefunded(string paymentId)
        {
            var payment = _context
                .Payments
                .FirstOrDefault(entity => entity.Id == paymentId);

            if (payment == null) return null;
            payment.Refunded = true;
            _context.Update(payment);
            await _context.SaveChangesAsync();
            return payment;

        }
    }
}