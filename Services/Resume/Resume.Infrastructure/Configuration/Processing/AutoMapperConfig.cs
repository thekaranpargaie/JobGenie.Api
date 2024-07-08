using AutoMapper;
using Resume.Infrastructure.AutoMapperProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Configuration.Processing
{
    public class AutoMapperConfig
    {

        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FilterProfile());
            });
            return mapperConfig.CreateMapper();
        }
    }
}
