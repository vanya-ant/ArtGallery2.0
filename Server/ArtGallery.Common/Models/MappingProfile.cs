namespace ArtGallery.Common.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class MappingProfile : Profile
    {
        public MappingProfile(Assembly assembly)
        {
            this.ApplyMappingsFromAssembly(assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                const string mappingMethod = "Mapping";

                var methodInfo = type.GetMethod(mappingMethod) ?? type.GetInterface("IMapFrom`1")?.GetMethod(mappingMethod); ;

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
