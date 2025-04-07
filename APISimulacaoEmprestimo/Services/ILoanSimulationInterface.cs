using APISimulacaoEmprestimo.DTO;

namespace APISimulacaoEmprestimo.Services
{
    public interface ILoanSimulationInterface
    {
        Task<LoanSimulationResponseDto> SimulateAsync(LoanSimulationRequestDto request);
    }
}
