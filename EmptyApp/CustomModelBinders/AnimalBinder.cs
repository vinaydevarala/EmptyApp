using EmptyApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmptyApp.CustomModelBinders
{
    public class AnimalBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            Animals animals = new Animals();
            if (bindingContext.ValueProvider.GetValue("Id").Length > 0)
            {
                animals.Id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Id").FirstValue);
            }
            if (bindingContext.ValueProvider.GetValue("AnimalName").Length > 0)
            {
                animals.AnimalName = bindingContext.ValueProvider.GetValue("AnimalName").FirstValue;
            }
            bindingContext.Result=ModelBindingResult.Success(animals);
            return Task.CompletedTask;
        }
    }
}
