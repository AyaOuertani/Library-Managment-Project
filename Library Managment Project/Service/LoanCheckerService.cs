
using LibraryManagment.Data;

namespace Library_Managment_Project.Service
{
    public class LoanCheckerService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer _timer;

        public LoanCheckerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckOverdueLoans, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        private void CheckOverdueLoans(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBcontext>();

                var overdueLoans = dbContext.LoansBooks
                    .Where(l => l.DateOfReturn < DateTime.Now  )
                    .ToList();

                foreach (var loan in overdueLoans)
                {
                    loan.LoanStatus = Enum.StatusOfLoans.Overdue;
                    dbContext.LoansBooks.Update(loan);
                }

                dbContext.SaveChanges();
            }
        }
    }
}
