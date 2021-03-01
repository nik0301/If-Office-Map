using System.Collections.Generic;
using OfficeMap.Business.Models;
using OfficeMap.Data;
using OfficeMap.Data.Models;
using Attribute = OfficeMap.Data.Models.Attribute;

namespace OfficeMap.Business
{
    public class ObjectAttributeData
    {
        private readonly ObjectAttributeRepo objectAttributeRepo;
        private readonly Authorization authorization;
        private readonly AttributeRepo attributeRepo;

        public ObjectAttributeData(AttributeRepo attributeRepo, ObjectAttributeRepo objectAttributeRepo, Authorization authorization)
        {
            this.objectAttributeRepo = objectAttributeRepo;
            this.authorization = authorization;
            this.attributeRepo = attributeRepo;
        }

        public List<ObjectAttribute> GetObjectAttributes(string userIdentity, int objectId)
        {
            CheckPermission(userIdentity);

            return objectAttributeRepo.GetObjectAttributes(objectId);
        }

        public void UpdateObjectAttribute(string userIdentity, int id, string value)
        {
            CheckPermission(userIdentity);

            var objAttr = objectAttributeRepo.GetById(id);

            if (objAttr == null)
            {
                throw new OfficeMapException("Nav objekta ar norādīto id.");
            }

            objAttr.Value = value;
            objectAttributeRepo.Update(objAttr);
        }

        public void DeleteObjectAttribute(string userIdentity, int id)
        {
            CheckPermission(userIdentity);

            objectAttributeRepo.Remove(id);
        }

        public ObjectAttributeCreate GetObjectAttributeCreate(string userIdentity, int id)
        {
            CheckPermission(userIdentity);

            return new ObjectAttributeCreate
            {
                Attributes = attributeRepo.GetNonExistingForObject(id),
                ObjectId = id
            };
        }

        public int AddObjectAttribute(string userIdentity, int objectId, bool isNewAttribute, string attributeId, string attributeName, string value)
        {
            CheckPermission(userIdentity);

            if (attributeRepo.GetById(attributeId) == null)
            {
                if (!isNewAttribute)
                {
                    throw new OfficeMapException("Izvēlētais attribūts neeksistē! Lūdzu mēģiniet vēlreiz.");
                }

                if (string.IsNullOrEmpty(attributeName))
                {
                    throw new OfficeMapException("Radās kļūda! Jaunā atribūta nosaukumam jābūt norādītam.");
                }

                attributeRepo.Add(new Attribute
                {
                    Id = attributeId,
                    Name = attributeName
                });
            }
            else
            {
                if (isNewAttribute)
                {
                    throw new OfficeMapException($"Attribūts ar identifikatoru '{attributeId}' jau eksistē!");
                }
            }

            var objAttr = new ObjectAttribute
            {
                ObjectId = objectId,
                AttributeId = attributeId,
                Value = value
            };

            objectAttributeRepo.Add(objAttr);

            return objAttr.Id;
        }

        public void CheckPermission(string userIdentity)
        {
            if (!authorization.IsSuperUser(userIdentity))
            {
                throw new OfficeMapException("Nav piekļuves tiesību.");
            }
        }
    }
}
