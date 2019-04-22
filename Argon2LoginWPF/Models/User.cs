
namespace Argon2LoginWPF.Models
{
    /// <summary>
    /// User model for login credentials
    /// </summary>
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SaltedPwHash { get; set; }
        public string Salt { get; set; }
    }
}
