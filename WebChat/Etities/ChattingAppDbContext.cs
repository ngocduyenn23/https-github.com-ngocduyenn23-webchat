using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebChat.Etities
{
    public class ChattingAppDbContext : DbContext
    {
        public DbSet<AppAddFriendTicket> AppAddFriendTickets { get; set; }
        public DbSet<AppAttachment> AppAttachments { get; set; }
        public DbSet<AppConversation> AppConversations { get; set; }
        public DbSet<AppConversationUserSeen> AppConversationUserSeens { get; set; }
        public DbSet<AppFriend> AppFriends { get; set; }
        public DbSet<AppMessage> AppMessages { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserConversation> AppUsersConversations { get; set; }
        public ChattingAppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // cấu hình bảng app user
            modelBuilder.Entity<AppUser>()
                .Property(m => m.Password)
                .HasMaxLength(200);
            modelBuilder.Entity<AppUser>()
               .Property(m => m.Username)
               .HasMaxLength(200);
            modelBuilder.Entity<AppUser>()
               .Property(m => m.Avatar)
               .HasMaxLength(300);
            modelBuilder.Entity<AppUser>()
               .Property(m => m.DisplayName)
               .IsRequired(true)   //not null
               .HasMaxLength(100);

            // Ràng buộc UNIQUE
            modelBuilder.Entity<AppUser>()
               .HasIndex(m => m.Username)
               .IsUnique(true);

            // Cấu hình bảng AppFriend
           /* modelBuilder.Entity<AppFriend>()
                .Property(m => m.OwnerId)
                .HasMaxLength(200);
            modelBuilder.Entity<AppFriend>()
                .Property(m => m.FriendId)
                .HasMaxLength(200);*/


            // Cấu hình AppAddFriendTicKet
           /* modelBuilder.Entity<AppAddFriendTicket>()
                .Property(m => m.)*/
        }
    }
}
