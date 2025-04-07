namespace APISimulacaoEmprestimo.DTO
{
    public class LoanSimulationResponseDto
    {
        public decimal MonthlyPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalPayment { get; set; }
        public List<PaymentScheduleItemDto> PaymentSchedule { get; set; }
    }
}
