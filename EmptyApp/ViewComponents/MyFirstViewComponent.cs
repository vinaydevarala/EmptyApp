using EmptyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmptyApp.ViewComponents
{
    [ViewComponent]
    public class MyFirstViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Animals> animals = new List<Animals>
    {
    new Animals() { AnimalName = "Lion", Description = "A large, carnivorous feline.", Id = 1 },
    new Animals() { AnimalName = "Tiger", Description = "A powerful big cat native to Asia.", Id = 2 },
    new Animals() { AnimalName = "Elephant", Description = "The largest land mammal.", Id = 3 },
    new Animals() { AnimalName = "Giraffe", Description = "The tallest living terrestrial animal.", Id = 4 },
    new Animals() { AnimalName = "Zebra", Description = "A species of African equid with distinctive black-and-white stripes.", Id = 5 },
    new Animals() { AnimalName = "Kangaroo", Description = "A marsupial from Australia known for its powerful hind legs.", Id = 6 },
    new Animals() { AnimalName = "Penguin", Description = "A flightless bird that lives in the Southern Hemisphere.", Id = 7 },
    new Animals() { AnimalName = "Panda", Description = "A large bear native to China, known for its black and white fur.", Id = 8 },
    new Animals() { AnimalName = "Cheetah", Description = "The fastest land animal, capable of reaching speeds of 60 to 70 mph.", Id = 9 },
    new Animals() { AnimalName = "Wolf", Description = "A wild carnivorous mammal closely related to dogs.", Id = 10 },
    new Animals() { AnimalName = "Eagle", Description = "A large bird of prey, known for its keen vision.", Id = 11 },
    new Animals() { AnimalName = "Shark", Description = "A large predator found in oceans, known for its sharp teeth.", Id = 12 },
    new Animals() { AnimalName = "Snake", Description = "A legless reptile, often associated with danger.", Id = 13 },
    new Animals() { AnimalName = "Gorilla", Description = "A large primate native to Africa, known for its intelligence.", Id = 14 },
    new Animals() { AnimalName = "Koala", Description = "A marsupial from Australia that feeds mainly on eucalyptus leaves.", Id = 15 },
    new Animals() { AnimalName = "Sloth", Description = "A slow-moving mammal found in Central and South America.", Id = 16 },
    new Animals() { AnimalName = "Otter", Description = "A carnivorous mammal known for its playful behavior.", Id = 17 },
    new Animals() { AnimalName = "Alligator", Description = "A large reptile found in freshwater environments.", Id = 18 },
    new Animals() { AnimalName = "Fox", Description = "A small to medium-sized carnivorous mammal.", Id = 19 },
    new Animals() { AnimalName = "Rabbit", Description = "A small herbivorous mammal with long ears.", Id = 20 }
};
            Animals? animals1 = animals.Where(animals => animals.Id == id).FirstOrDefault();

            ViewBag.animals = animals;
            if (animals1 != null)
            {
                return View(animals1);
            }
            return View("Index", animals);
        }
    }
}
