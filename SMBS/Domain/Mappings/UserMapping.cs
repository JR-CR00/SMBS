using Mapster;

public class UserMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApplicationUser, UserDto>();
        config.NewConfig<CreateUserDto, ApplicationUser>()
            .Map(dest => dest.UserStatusId, src => UserStatusEnum.Active);
    }
}