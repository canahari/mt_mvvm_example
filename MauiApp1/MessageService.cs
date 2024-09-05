using MassTransit.Mediator;
using MauiApp1.Contracts;
using Timer = System.Timers.Timer;

namespace MauiApp1
{
    internal class MessageService
    {
        private readonly IMediator mediator;
        private readonly Timer timer;

        public MessageService(IMediator mediator)
        {
            this.mediator = mediator;  
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            mediator.Publish<IMessageChanged>(new
            {
                NewText = Guid.NewGuid().ToString()
            });
        }
    }
}
