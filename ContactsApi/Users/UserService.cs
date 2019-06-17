namespace ContactsApi.Users
{
    public class UserService : IUserService
    {
        public UserDto ConvertToDtoFromUser(User user)
        {
            if (user == null) return null;

            return new UserDto(user);
        }
    }
}