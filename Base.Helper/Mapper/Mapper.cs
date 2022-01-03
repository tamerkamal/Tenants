using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Base.Helpers.Mapper
{
    public class Mapper
    {
        private static Mapper _instance;
        public static Mapper Instance => _instance ??= new Mapper();

        public TDestination Map<TSource, TDestination>(TSource realObject)
            where TSource : class, new()
            where TDestination : class, new()
        {
            var dtoObject = new TDestination();
            return Map(realObject, dtoObject);
        }

        public TDestination Map<TSource, TDestination>(TSource realObject, TDestination dtoObject)
           where TSource : class, new()
           where TDestination : class, new()
        {
            var realObjectType = realObject?.GetType();
            var properties = realObjectType?.GetProperties();

            if (properties != null)
                foreach (var currentRealProperty in properties)
                {
                    var currentDtoProperty = dtoObject.GetType().GetProperty(currentRealProperty.Name,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (currentDtoProperty != null)
                    {
                        currentDtoProperty.SetValue(dtoObject, currentRealProperty.GetValue(realObject, null));
                    }
                }

            return dtoObject;
        }

        public List<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> realObjects)
            where TSource : class, new()
            where TDestination : class, new()
        {
            return realObjects.Select(Map<TSource, TDestination>).ToList();
        }
    }
}