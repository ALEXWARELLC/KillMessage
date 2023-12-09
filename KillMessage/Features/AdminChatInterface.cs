using Exiled.API.Features;

namespace KillMessage.Features
{
    public class AdminChatInterface
    {
        public static void LogToAdminChat(string Message)
        {
            Log.Warn($"Sending message to AdminChat: '{Message}'");
            ReferenceHub.HostHub.encryptedChannelManager.TrySendMessageToClient($"0!{Message}", EncryptedChannelManager.EncryptedChannel.AdminChat);
        }
    }
}