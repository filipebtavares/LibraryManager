using System.ComponentModel.DataAnnotations;
using LibraryManager.Api.Entity;

namespace LibraryManager.Api.Model
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User FromEntity()
            => new User(Name, Email);
    }
}
