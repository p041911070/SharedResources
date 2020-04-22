using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.Categories;
using EasyAbp.SharedResources.Categories.Dtos;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Categories.Category
{
    public class EditModalModel : SharedResourcesPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateCategoryDto Category { get; set; }

        private readonly ICategoryAppService _service;

        public EditModalModel(ICategoryAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            Category = ObjectMapper.Map<CategoryDto, CreateUpdateCategoryDto>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, Category);
            return NoContent();
        }
    }
}