using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Uniforms.Core.Exceptions;

namespace Uniforms.Core.Entities
{
    /// <summary>
    /// Represent a dynamic entity with key value access.
    /// </summary>
    public class DynamicEntity
    {
        // entity properties dictionary
        private Dictionary<string, object> _properties;

        // initialize default entity properties
        public DynamicEntity()
        {
            _properties = new Dictionary<string, object>
            {
                { "Id", null },
                { "CreatedAt", default(DateTime) },
                { "CreatedBy", null },
                { "ModifiedAt", default(DateTime) },
                { "ModifiedBy", null },
                { "IsActive", false },
                { "IsDeleted", false },
                { "Status", 0 }
            };
        }

        #region Default Properties

        public string Id { get { return (string)_properties["Id"]; } }
        public DateTime CreatedAt { get { return (DateTime)_properties["CreatedAt"]; } }
        public string CreatedBy { get { return (string)_properties["CreatedBy"]; } }
        public DateTime ModifiedAt { get { return (DateTime)_properties["ModifiedAt"]; } }
        public string ModifiedBy { get { return (string)_properties["ModifiedBy"]; } }
        public bool IsActive { get { return (bool)_properties["IsActive"]; } }
        public bool IsDeleted { get { return (bool)_properties["IsDeleted"]; } }
        public int Status { get { return (int)_properties["Status"]; } }

        #endregion

        // Get entity property by given property name and generic type
        public T GetPropertyValue<T>(string propertyName)
        {
            if (_properties.ContainsKey(propertyName))
            {
                try
                {
                    return (T)GetPropertyValue(propertyName);
                }
                catch (Exception e)
                {
                    throw new WrongPropertyCastException(e.Message);
                }
            }
            else
            {
                throw new PropertyNotExistsException();
            }
        }

        // Get entity property by given property name
        public object GetPropertyValue(string propertyName)
        {
            return this[propertyName];
        }

        // Get entity property by given property name
        public object this[string propertyName]
        {
            get
            {
                return _properties[propertyName];
            }
            set
            {
                _properties[propertyName] = value;
            }
        }

        // Cast the dynamic entity into generic type
        public T CastTo<T>()
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type, false);
            var properties = from source in type.GetMembers().ToList()
                             where source.MemberType == MemberTypes.Property
                             select source;
            List<MemberInfo> members = properties.Where(memberInfo => properties.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                try
                {
                    value = _properties.ContainsKey(memberInfo.Name) ? _properties[memberInfo.Name] : null;
                    propertyInfo.SetValue(obj, value, null);
                }
                catch { }
            }
            return (T)obj;
        }

        // Get the type of propertyName
        public Type TypeOf(string propertyName)
        {
            return _properties[propertyName].GetType();
        }

        // Check if this entity has property propertyName
        public bool HasProperty(string propertyName)
        {
            return _properties.ContainsKey(propertyName);
        }

        // Check if this entity has value on propertyName
        public bool HasValue(string propertyName)
        {
            return HasProperty(propertyName) && _properties[propertyName] != null;
        }

        // Cast the dynamic entity into generic type by given dynamic entity reference
        public static T CastTo<T>(DynamicEntity entity)
        {
            return entity.CastTo<T>();
        }

        // Create a dynamic entity by given an object
        public static DynamicEntity CreateFromObject(object obj)
        {
            DynamicEntity entity = new DynamicEntity();

            if (obj != null)
            {
                Type objectType = obj.GetType();
                var properties = from source in objectType.GetMembers().ToList()
                                 where source.MemberType == MemberTypes.Property
                                 select source;
                List<MemberInfo> members = properties
                    .Where(memberInfo => properties.Select(c => c.Name)
                    .ToList().
                    Contains(memberInfo.Name)).
                    ToList();
                object value;
                foreach (var memberInfo in members)
                {
                    try
                    {
                        if (IsCollectionOrEnumerable(memberInfo))
                            continue;

                        value = objectType.GetProperty(memberInfo.Name).GetValue(obj, null);
                        entity[memberInfo.Name] = value;
                    }
                    catch
                    {
                        entity[memberInfo.Name] = null;
                    }
                }
            }

            return entity;
        }

        private static bool IsCollectionOrEnumerable(MemberInfo memberInfo)
        {
            var implementedInterfaces = ((TypeInfo)((PropertyInfo)memberInfo).PropertyType).ImplementedInterfaces.Select(i => i.FullName);

            if (implementedInterfaces.Any(i => i.Contains("IList") || i.Contains("ICollection") || i.Contains("IEnumerable")))
            {
                return true;
            }

            return false;
        }
    }
}
