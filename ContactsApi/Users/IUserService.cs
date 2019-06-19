namespace ContactsApi.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Converts a given User object into a UserDto by instantiating an object
        /// without any ASP.NET Identity fields and properties.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>UserDto</returns>
        UserDto ConvertToDtoFromUser(AppUser user);
    }
}