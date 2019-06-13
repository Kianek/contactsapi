namespace ContactsApi.Users
{
    public class UserService : IUserService
    {
        public UserDto ConvertToDtoFromUser(User user)
        {
            return new UserDto(user);
        }
    }
}