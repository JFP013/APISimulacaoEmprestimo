using System.ComponentModel.DataAnnotations;

namespace APISimulacaoEmprestimo.DTO
{
    public class LoanSimulationRequestDto
    {
        [Required(ErrorMessage = "O valor do empréstimo é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor do empréstimo deve ser maior que zero.")]
        public decimal LoanAmount { get; set; }

        [Required(ErrorMessage = "A taxa de juros é obrigatória.")]
        [Range(0.0000001, 1, ErrorMessage = "A taxa de juros deve ser maior que 0 e menor ou igaul a 1.")]
        public decimal AnnualInterestRate { get; set; }

        [Required(ErrorMessage = "O número de meses é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O número de meses deve ser maior que zero.")]
        public int NumberOfMonths { get; set; }
    }
}
