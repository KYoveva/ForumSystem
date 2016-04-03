namespace ForumSystem.Web.MVC.Areas.Administrative.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data.Contracts;

    [Authorize(Roles = "admin")]
    public class CategoriesController : Controller
    {
        private IForumPostCategoriesService categories;

        public CategoriesController(IForumPostCategoriesService categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ForumPostCategories_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.categories.AllForumPostCategories()
                .ProjectTo<ForumPostCategoriesViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ForumPostCategories_Create([DataSourceRequest]DataSourceRequest request, ForumPostCategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var entity = new ForumPostCategory
                {
                    Name = category.Name,
                    Description = category.Description
                };

                this.categories.AddCategory(entity);
                category.Id = entity.Id;

            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ForumPostCategories_Update([DataSourceRequest]DataSourceRequest request, ForumPostCategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var categoryToEdit = this.categories
               .AllForumPostCategories()
               .Where(c => c.Id == category.Id)
               .FirstOrDefault();

                if (categoryToEdit == null)
                {
                    return null;
                }

                categoryToEdit.Name = category.Name;
                categoryToEdit.Description = category.Description;

                this.categories.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ForumPostCategories_Destroy([DataSourceRequest]DataSourceRequest request, ForumPostCategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var entity = new ForumPostCategory
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };

                this.categories.Delete(entity);
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
