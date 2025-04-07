using APISimulacaoEmprestimo.DTO;
using APISimulacaoEmprestimo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISimulacaoEmprestimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanSimulationController : ControllerBase
    {
        private readonly ILoanSimulationInterface _loanSimulationService;

        public LoanSimulationController(ILoanSimulationInterface loanSimulationService)
        {
            _loanSimulationService = loanSimulationService;
        }

        [HttpPost("simulate")]
        public async Task<IActionResult> Simulate([FromBody] LoanSimulationRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _loanSimulationService.SimulateAsync(request);
            return Ok(result);
        }
    }
}
