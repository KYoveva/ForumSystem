namespace ForumSystem.Web.MVC.Infrastructure.Mappings
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
