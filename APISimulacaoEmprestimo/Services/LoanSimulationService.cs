using APISimulacaoEmprestimo.Data;
using APISimulacaoEmprestimo.DTO;
using APISimulacaoEmprestimo.Models;

namespace APISimulacaoEmprestimo.Services
{
    public class LoanSimulationService : ILoanSimulationInterface
    {
        private readonly AppDbContext _context;

        public LoanSimulationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LoanSimulationResponseDto> SimulateAsync(LoanSimulationRequestDto request)
        {
            // 1. Criar e salvar a proposta
            PropostaModel proposta = new PropostaModel
            {
                LoanAmount = request.LoanAmount,
                AnnualInterestRate = request.AnnualInterestRate,
                NumberOfMonths = request.NumberOfMonths
            };

            await _context.Proposta.AddAsync(proposta);
            await _context.SaveChangesAsync();

            // 2. Calcular parcela mensal (Tabela Price)
            decimal monthlyRate = request.AnnualInterestRate / 12;
            decimal factor = (decimal)Math.Pow(1 + (double)monthlyRate, request.NumberOfMonths);
            decimal monthlyPayment = request.LoanAmount * monthlyRate * factor / (factor - 1);
            monthlyPayment = Math.Round(monthlyPayment, 2);

            // 3. Gerar parcelas
            List<PaymentScheduleItemModel> paymentSchedule = new List<PaymentScheduleItemModel>();
            decimal remainingBalance = request.LoanAmount;
            decimal totalInterest = 0;

            for (int month = 1; month <= request.NumberOfMonths; month++)
            {
                decimal interest = remainingBalance * monthlyRate;
                decimal principal = monthlyPayment - interest;
                remainingBalance -= principal;

                if (remainingBalance < 0)
                    remainingBalance = 0;

                totalInterest += interest;

                paymentSchedule.Add(new PaymentScheduleItemModel
                {
                    Month = month,
                    Interest = Math.Round(interest, 2),
                    Principal = Math.Round(principal, 2),
                    Balance = Math.Round(remainingBalance, 2)
                });
            }

            // 4. Salvar resumo
            var summary = new PaymentFlowSummaryModel
            {
                PropostaId = proposta.Id,
                MonthlyPayment = Math.Round(monthlyPayment, 2),
                TotalInterest = Math.Round(totalInterest, 2),
                TotalPayment = Math.Round(monthlyPayment * request.NumberOfMonths, 2),
                PaymentScheduleItems = paymentSchedule
            };

            await _context.PaymentFlowSummary.AddAsync(summary);
            await _context.SaveChangesAsync();

            // 5. Retornar resposta
            var response = new LoanSimulationResponseDto
            {
                MonthlyPayment = summary.MonthlyPayment,
                TotalInterest = summary.TotalInterest,
                TotalPayment = summary.TotalPayment,
                PaymentSchedule = paymentSchedule.Select(p => new PaymentScheduleItemDto
                {
                    Month = p.Month,
                    Interest = p.Interest,
                    Principal = p.Principal,
                    Balance = p.Balance
                }).ToList()
            };

            return response;
        }


    }
}
