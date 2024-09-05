using MassTransit;
using MauiApp1.Contracts;
using System.ComponentModel;

namespace MauiApp1
{
    public class MainPageViewModel : 
        INotifyPropertyChanged, 
        IConsumer<IMessageChanged>
    {
        private string? message;
        public string? Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public async Task Consume(ConsumeContext<IMessageChanged> context)
        {
            Message = context.Message.NewText;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
