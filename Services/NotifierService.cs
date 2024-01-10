namespace ChatAppExample.Services
{
    public class NotifierService
    {
        public event EventHandler<MessageEventArgs> NewMessage;
        public List<string> messages = new();

        protected virtual void OnNewMessage(string message)
        {
            if (NewMessage != null)
            {
                NewMessage?.Invoke(this, new MessageEventArgs(message));
                messages.Add(message);
            }
        }
        public void SendMessage(string message)
        {
            if (NewMessage != null)
            {
                Console.WriteLine($"Message Sent: {message}");
                OnNewMessage(message);
            }
        }
    }
}
