using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Domain.Enums;


namespace Blog.Core.Application.Extensions
{
    public static class SafeMapper
    {
        public static Result<TMapTo> MapSafely<TMapTo>(this IMapper mapper, object mapFrom)
        {
            if (mapper == null)
                return ErrorTypess.ValidationMissMatch.Because("the Source type cant be null");
            try
            {
                return mapper.Map<TMapTo>(mapFrom);
            }
            catch (AutoMapperConfigurationException)
            {
                return ErrorTypess.Exeption.Because("Mapping configuration error");
            }
            catch (AutoMapperMappingException)
            {
                return ErrorTypess.Exeption.Because("Mapping error");
            }
        }
    }
}
