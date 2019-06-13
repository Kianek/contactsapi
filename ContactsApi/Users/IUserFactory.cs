namespace ContactsApi.Users
{
  public interface IUserFactory<T>
  {
        T Build();
  }
}