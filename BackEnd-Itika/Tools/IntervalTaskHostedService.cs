using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BackEnd_Itika.Data;




namespace BackEnd_Itika.Tools
{
   
    public class IntervalTaskHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly BiometricoData _biometricoData;


      
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CargarBiometricoDiario, null,TimeSpan.Zero,TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }
        private void CargarBiometricoDiario(object state) 
        {
            // cargar modelo de cargar mediante las entidades
            //_biometricoData.Add_RegistroBiometrico();
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite,0);
            return Task.CompletedTask;

        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
