using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using OfficeMap.Business;

namespace OfficeMap.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/ObjectAttributesApi")]
    public class ObjectAttributesApiController : Controller
    {
        private readonly ObjectAttributeData objectAttributeData;

        public ObjectAttributesApiController(ObjectAttributeData objectAttributeData)
        {
            this.objectAttributeData = objectAttributeData;
        }

        // POST: api/ObjectAttributesApi
        [HttpPost]
        public IActionResult Post(NewObjectAttributeCreate objAttrCreate)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "Radās kļūda pievienojot datus! Lūdzu, mēģiniet vēlreiz.");
            }

            try
            {
                var id = objectAttributeData.AddObjectAttribute(User?.Identity?.Name, objAttrCreate.ObjectId, objAttrCreate.IsNewAttribute, objAttrCreate.AttributeId, objAttrCreate.AttributeName, objAttrCreate.Value);
                return Ok(id);
            }
            catch (OfficeMapException e)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, e.Message);
            }
        }

        // PUT: api/ObjectAttributesApi
        [HttpPut]
        public IActionResult Put(AttributeValue attributeValue)
        {
            if (string.IsNullOrEmpty(attributeValue.NewValue))
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "Aizpildiet jaunās vērtības lauku!");
            }

            objectAttributeData.UpdateObjectAttribute(User?.Identity?.Name, attributeValue.Id, attributeValue.NewValue);
            return Ok();
        }

        // DELETE: api/ObjectAttributesApi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            objectAttributeData.DeleteObjectAttribute(User?.Identity?.Name, id);
        }
    }

    public class AttributeValue
    {
        public int Id { get; set; }
        public string NewValue { get; set; }
    }
}
