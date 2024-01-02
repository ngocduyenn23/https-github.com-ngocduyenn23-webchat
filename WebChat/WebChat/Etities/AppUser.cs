namespace WebChat.Etities
{
    public class AppUser
    {
        public int Id {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
        public string? Avatar {get; set;}
        public string DisplayName {get; set;}
        public DateTime CreateAt { get; set; }

    }
}
