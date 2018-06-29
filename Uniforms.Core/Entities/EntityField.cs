using System;
using System.Collections.Generic;
using System.Text;

namespace Uniforms.Core.Entities
{
    public class EntityField : BaseEntity
    {
        public string EntityId { get; set; }
        public string FieldTypeId { get; set; }
        public string ColumnName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool IsChanged { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsRequired { get; set; }
        public bool IsSearchable { get; set; }
        public int MaxLength { get; set; }
        public EntityFieldType FieldType { get; set; }
        public IEnumerable<EntityFieldNameValue> ValueOptions { get; set; }
    }
}
