namespace WebChat.Etities
{
    public class AppMessage
    {
        public long Id {get; set; }
        public string Content {get; set; }
        public int Sender {get; set; }
        public long ConversationId {get; set; }
        public bool HasAttachment {get; set; }
        public DateTime SendAt { get; set; }

    }
}
