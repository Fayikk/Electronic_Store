using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyInjection.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            //For Category
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            //For Shop
            builder.RegisterType<ShopManager>().As<IShopService>().SingleInstance();
            builder.RegisterType<EfShopDal>().As<IShopDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            //For authorization (Yetkilendirme işlemleri)
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            //For add Images
            //builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            //builder.RegisterType<EfProductImageDal>().As<IProductImageDal>().SingleInstance();

            builder.RegisterType<FileHelperManager>().As<IFileHelperService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
