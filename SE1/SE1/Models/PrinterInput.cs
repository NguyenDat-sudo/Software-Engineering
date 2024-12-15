

using Microsoft.AspNetCore.Mvc.Rendering;

namespace SE1.Models
{
    public class PrinterInput
    {
        public string printer {get;set; }
        public List<SelectListItem> Printers { get; set; }
    }
}
