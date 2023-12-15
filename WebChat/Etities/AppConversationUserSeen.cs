namespace WebChat.Etities
{
    public class AppConversationUserSeen
    {
         public long Id {get; set;}
         public int UserId {get; set;}
         public long ConversationId {get; set;}
         public long LastSeenMessageId {get; set;}
         public DateTime LastSeenAt { get; set; }

    }
}
