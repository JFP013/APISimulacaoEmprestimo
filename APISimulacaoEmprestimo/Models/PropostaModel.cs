namespace APISimulacaoEmprestimo.Models
{
    public class PropostaModel
    {
        public int Id { get; set; }

        public decimal LoanAmount { get; set; } // Valor do empréstimo
        public decimal AnnualInterestRate { get; set; } // Juros anuais
        public int NumberOfMonths { get; set; } // Parcelas

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public PaymentFlowSummaryModel PaymentFlowSummary { get; set; }
    }
}
