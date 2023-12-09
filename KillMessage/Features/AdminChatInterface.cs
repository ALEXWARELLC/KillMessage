using Exiled.API.Features;

namespace KillMessage.Features
{
    public class AdminChatInterface
    {
        public static void LogToAdminChat(string Message)
        {
            Log.Warn($"Sending message to AdminChat: '{Message}'");
            RemoteAdmin.CommandProcessor.ProcessAdminChat(Message, null);
        }
    }
}
