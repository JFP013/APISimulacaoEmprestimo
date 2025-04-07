using APISimulacaoEmprestimo.Models;
using Microsoft.EntityFrameworkCore;

namespace APISimulacaoEmprestimo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PropostaModel> Proposta { get; set; }
        public DbSet<PaymentFlowSummaryModel> PaymentFlowSummary { get; set; }
        public DbSet<PaymentScheduleItemModel> PaymentScheduleItem { get; set; }
    }
}
