using MessageAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MessageAPI.Persistence

{
    public class MessageApiContext : DbContext
    {
        public MessageApiContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<UserModel> UserModel { get; set; } = default!;
        public DbSet<MessageModel> MessageModel { get; set; } = default!;



    }
}
