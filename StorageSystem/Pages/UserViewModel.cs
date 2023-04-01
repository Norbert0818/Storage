using CoreBuisness.User;

namespace StorageSystem.Pages
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public UserRole Rank { get; set; }
    }

}
