using EmptyApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace EmptyApp.CustomModelBinders
{
    public class BinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Animals))
            {
                return new BinderTypeModelBinder(typeof(AnimalBinder));
            }
            return null;
        }
    }
}
