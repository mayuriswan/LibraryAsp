using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibrairieDTICRosemont.Models; // Assurez-vous que le namespace est correct

public class CategoriesMenuViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var categories = SampleDonnes.getCategories(); // Chargez vos catégories depuis SampleDonnes
        return View("CategoriesMenu", categories);
    }
}
