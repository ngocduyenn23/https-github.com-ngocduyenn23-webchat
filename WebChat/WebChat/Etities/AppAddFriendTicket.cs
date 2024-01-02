namespace WebChat.Etities
{
    public class AppAddFriendTicket
    {
        public int Id {get; set;}
        public int? SenderId {get; set;}
        public int? TargetId {get; set;}
        public string Message {get; set;}
        public bool? IdAccept {get; set;}
        public DateTime SendAt { get; set; }

    }
}
