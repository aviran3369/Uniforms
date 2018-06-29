using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uniforms.ViewModels
{
    public class EntityModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string DatabaseTableName { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        public int Status { get; set; }
        public IList<EntityPropertyModel> Properties { get; set; }
    }
}
