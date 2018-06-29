using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uniforms.ViewModels
{
    public class EntityPropertyModel
    {
        public string Id { get; set; }
        public string ColumnName { get; set; }
        public string DisplayName { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsRequierd { get; set; }
        public bool IsSearchable   { get; set; }
        public bool IsDeleted { get; set; }
        public int MaxLength { get; set; }
    }
}
