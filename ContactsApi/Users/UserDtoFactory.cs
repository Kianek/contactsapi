namespace ContactsApi.Users
{
  public class UserDtoFactory : IUserFactory<UserDto>
  {
    public UserDto Build(User user)
    {
      return new UserDto(user);
    }
  }
}