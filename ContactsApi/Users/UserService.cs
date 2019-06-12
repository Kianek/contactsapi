namespace ContactsApi.Users
{
  public class UserService : IUserService
  {
    // TODO: Add UserFactory and UserDtoFactory
    public UserDto ConvertToDto(User user)
    {
      return new UserDto(user);
    }
  }
}