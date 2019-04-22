using Argon2LoginWPF.Models;
using System.Data.Entity;



namespace Argon2LoginWPF.Database
{
    /// <summary>
    /// Code first entity framework settings
    /// </summary>
    public class UserDbContext : DbContext
    {
        /// <summary>
        /// Table the database with User property columbs
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Constructor for connection. class name equals with ConnectionString name in app.config
        /// </summary>
        public UserDbContext() : base() { }

    }
}
