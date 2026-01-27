using Models;

public class PaymentService
{
    private readonly IPaymentGateway _paymentGateway;
    private readonly IPaymentValidator _paymentValidator;
    private readonly ISmsService _smsService;
    private readonly ITransactionLogger _transactionLogger;

    public PaymentService(
        IPaymentGateway paymentGateway,
        IPaymentValidator paymentValidator,
        ISmsService smsService,
        ITransactionLogger transactionLogger
    )
    {
        _paymentGateway = paymentGateway;
        _paymentValidator = paymentValidator;
        _smsService = smsService;
        _transactionLogger = transactionLogger;
    }

    public void ProccesorPayment(Payment payment)
    {
        try
        {
            // Визває валідатор
            _paymentValidator.IsValid(payment);

            // Списання коштів
            decimal chargeAmount = _paymentGateway.Charge(payment);

            // Логування
            string message = $"Ваш платіж успішний! Сума: {chargeAmount}";

            _transactionLogger.Log(payment, message);
            
            // Відправка SMS
            _smsService.SendMessage(payment, message);
        }
        catch(Exception ex)
        {
            string errorMessage = $"Помилка платежу {ex.Message}";
            _transactionLogger.Log(payment, errorMessage);
            _smsService.SendMessage(payment, errorMessage);
        }
    }
}