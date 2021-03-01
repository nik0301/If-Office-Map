using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeMap.Business;

namespace OfficeMap.Web.Controllers
{
    public class ObjectAttributeController : Controller
    {
        private readonly ObjectAttributeData objectAttributeData;

        public ObjectAttributeController(ObjectAttributeData objectAttributeData)
        {
            this.objectAttributeData = objectAttributeData;
        }

        // GET: ObjectAttribute/Index/5
        public IActionResult Index(int id)
        {
            var details = objectAttributeData.GetObjectAttributes(User?.Identity?.Name, id);

            return View(details);
        }

        // GET: ObjectAttribute/Create/5
        public IActionResult Create(int id)
        {
            var objAttrCreate = objectAttributeData.GetObjectAttributeCreate(User?.Identity?.Name, id);

            var attributesSelectList = objAttrCreate.Attributes.Select(attribute => new SelectListItem
            {
                Text = attribute.Name,
                Value = attribute.Id
            });

            var model = new NewObjectAttributeCreate
            {
                Attributes = attributesSelectList,
                ObjectId = id
            };

            return PartialView("CreatePartialView", model);
        }
    }

    public class NewObjectAttributeCreate
    {
        public int ObjectId { get; set; }

        [Required(ErrorMessage = "Lūdzu izvēlieties vērtību no saraksta")]
        [DisplayName("Attribūts")]
        public string AttributeId { get; set; }

        public string AttributeName { get; set; }

        public bool IsNewAttribute { get; set; }

        public IEnumerable<SelectListItem> Attributes { get; set; }

        [Required(ErrorMessage = "Lūdzu aizpildiet vērtības ievadlauku")]
        [MaxLength(50, ErrorMessage = "Lūdzu ievadiet ne vairāk kā 50 rakstzīmes")]
        [DisplayName("Vērtība")]
        public string Value { get; set; }
    }
}