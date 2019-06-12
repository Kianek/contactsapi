namespace ContactsApi.Users
{
  public interface IUserService
  {
    UserDto ConvertToDto(User user);
  }
}