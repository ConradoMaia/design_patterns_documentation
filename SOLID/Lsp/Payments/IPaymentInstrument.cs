namespace Lsp.Payments
{
    interface IPaymentInstrument
    {

        void Validate();
        void CollectPayment();

    }
}
