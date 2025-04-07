namespace APISimulacaoEmprestimo.Models
{
    public class PaymentScheduleItemModel
    {
        public int Id { get; set; }

        public int Month { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }

        public int PaymentFlowSummaryId { get; set; }
        public PaymentFlowSummaryModel PaymentFlowSummary { get; set; }
    }
}
