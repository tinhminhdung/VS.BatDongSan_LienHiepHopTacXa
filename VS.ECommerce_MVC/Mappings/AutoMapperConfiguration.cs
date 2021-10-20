using AutoMapper;
using VS.ECommerce_MVC.Models;

namespace TeduShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entity.Album, AlbumViewModel>();
                cfg.CreateMap<Entity.Products, ProductViewModel>();
                cfg.CreateMap<Entity.News, NewsViewModel>();
                cfg.CreateMap<Entity.VideoClip, VideoViewModel>();
            });
        }

    }
}