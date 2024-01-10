namespace ChatAppExample.Services
{
    public class NotificationService
    {
        public void Subscribe(NotifierService notifier)
        {
            // Subscribe to the 'NewMessage' evet
            notifier.NewMessage += HandleNewMessage;
        }

        public void HandleNewMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"New Message: {e.Message}");
            // Logic to send a real time notification to the user
        }
    }
}
