using AutoMapper;
using WindsorX_2027.LagerModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WindsorX_2027.LagerRepositoryMappe
{
    public class LagerProfile : Profile
    {
        public LagerProfile()
        {

            CreateMap<Lagermodel, DisplayLagerData>();
            CreateMap<DisplayLagerData, Lagermodel>();

            // tillæg CreateMap<Lager_Data, DisplayLagerData>().
            //Formember(dest=> dest.varenummer, opt =>opt.MapFrom (src=> src.varenummer));

        }
    }
}
