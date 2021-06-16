using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebstoreAPI.Contracts;
using WebstoreAPI.Services;

namespace API.Controllers
{
    
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize(Roles = Role.API)]
        [HttpPut]
        [Route(ApiRoutes.Payments.CompletePayment)]
        public async Task<IActionResult> CompletePayment([FromBody] string paymentId)
        {
            var payment = await _paymentService.CompletePayment(paymentId);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [Authorize(Roles = Role.API)]
        [HttpPut]
        [Route(ApiRoutes.Payments.RefundPayment)]
        public async Task<IActionResult> RefundPayment(string paymentId)
        {
            var payment = await _paymentService.MarkPaymentAsRefunded(paymentId);
            if (payment == null) return NotFound();
            return Ok(payment);
        }
    }
}