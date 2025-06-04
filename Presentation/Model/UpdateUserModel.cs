using LibraryManager.Api.Domain.Entity;

namespace LibraryManager.Api.Presentation.Model
{
    public class UpdateUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User FromEntity()
            => new User(Name, Email);
    }
}
