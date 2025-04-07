namespace APISimulacaoEmprestimo.Models
{
    public class PaymentFlowSummaryModel
    {
        public int Id { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalPayment { get; set; }
        public int PropostaId { get; set; }

        public PropostaModel Proposta { get; set; }

        public ICollection<PaymentScheduleItemModel> PaymentScheduleItems { get; set; } = new List<PaymentScheduleItemModel>();
    }
}
