using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

// TODO: change this namespace to match Ankur's backend project
namespace StudioRags.Api.Controllers;

[ApiController]
[Route("api/payment")]
public class PaymentController : ControllerBase
{
    private readonly IConfiguration _config;

    public PaymentController(IConfiguration config)
    {
        _config = config;
        // Secret key comes from user-secrets locally / App Service settings on Azure.
        StripeConfiguration.ApiKey = _config["Stripe:SecretKey"];
    }

    // POST /api/payment/create-checkout-session
    [HttpPost("create-checkout-session")]
    public async Task<IActionResult> CreateCheckoutSession()
    {
        if (string.IsNullOrWhiteSpace(StripeConfiguration.ApiKey))
            return StatusCode(500, new { error = "Stripe:SecretKey is not configured." });

        var frontendUrl = _config["Stripe:FrontendUrl"] ?? "http://localhost:5173";

        var options = new SessionCreateOptions
        {
            Mode = "payment",
           
            LineItems = new List<SessionLineItemOptions>
            {
                new()
                {
                    Quantity = 1,
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "aud",
                        UnitAmount = 100, // AUD $1.00 (amount is in cents)
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Studio Rags Test Payment"
                        }
                    }
                }
            },
            SuccessUrl = $"{frontendUrl}/payment-success?session_id={{CHECKOUT_SESSION_ID}}",
            CancelUrl = $"{frontendUrl}/payment-cancelled"
        };

        try
        {
            var session = await new SessionService().CreateAsync(options);
            return Ok(new { url = session.Url });
        }
        catch (StripeException ex)
        {
            return BadRequest(new { error = ex.StripeError?.Message ?? ex.Message });
        }
    }

    // GET /api/payment/session-status?session_id=cs_test_...
    [HttpGet("session-status")]
    public async Task<IActionResult> SessionStatus([FromQuery(Name = "session_id")] string sessionId)
    {
        if (string.IsNullOrWhiteSpace(sessionId))
            return BadRequest(new { error = "session_id is required." });

        try
        {
            var session = await new SessionService().GetAsync(sessionId);
            return Ok(new
            {
                paymentStatus = session.PaymentStatus, // "paid" when successful
                amountTotal = session.AmountTotal,     // in cents
                currency = session.Currency
            });
        }
        catch (StripeException ex)
        {
            return BadRequest(new { error = ex.StripeError?.Message ?? ex.Message });
        }
    }
}
