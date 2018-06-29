using System;
using System.Collections.Generic;
using System.Text;

namespace Uniforms.Core.Entities
{
    /// <summary>
    /// Represent definition of customizable entity
    /// </summary>
    public class EntityDefinition : BaseEntity
    {
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string Description { get; set; }
        public string DatabaseTableName { get; set; }
        public int Version { get; set; }
        public bool IsChanged { get; set; }
        public bool IsPublished { get; set; }
        public IEnumerable<EntityField> CustomFields { get; set; }
    }
}
