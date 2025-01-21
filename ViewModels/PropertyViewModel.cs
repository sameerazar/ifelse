using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomIdentity.ViewModels
{
    public class PropertyViewModel
    {
        public string Property_Type { get; set; }
        public List<SelectListItem> PropertyTypes { get; set; }
    }
}
