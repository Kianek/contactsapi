namespace ContactsApi.Users
{
    public class UserService : IUserService
    {
        public UserDto ConvertToDtoFromUser(AppUser user)
        {
            if (user == null) return null;

            return new UserDto(user);
        }
    }
}