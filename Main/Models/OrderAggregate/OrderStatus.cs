using System.Runtime.Serialization;

namespace Main.Models.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pagamento Pendente")]
        Pending,

        [EnumMember(Value = "Pagamento Confirmado")]
        PaymentReceived,

        [EnumMember(Value = "Pagamento Recusado")]
        PaymentFailed
    }
}