namespace ContactsApi.Users
{
    public class UserDtoFactory : IUserFactory<UserDto>
    {
        private UserDto user;

        // Instantiates a new UserDto.
        public UserDtoFactory() => user = new UserDto();

        // Instantiates a new UserDto with a User's front-facing properties.
        public UserDtoFactory(User user) => this.user = new UserDto(user);

        public UserDto Build()
        {
            return this.user;
        }
    }
}