namespace ForumSystem.Web.MVC.Areas.Administrative.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using ForumSystem.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data.Contracts;

    [Authorize(Roles = Admin.AdminRole)]
    public class CategoriesController : Controller
    {
        private IForumPostCategoriesService categories;

        public CategoriesController(IForumPostCategoriesService categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult ForumPostCategories_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.categories.AllForumPostCategories()
                .ProjectTo<ForumPostCategoriesViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
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

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
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

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
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

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

        // protected override void Dispose(bool disposing)
        // {
        //    db.Dispose();
        //    base.Dispose(disposing);
        // }
    }
}
