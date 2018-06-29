using System;
using System.Collections.Generic;
using System.Text;

namespace Uniforms.Core.Entities
{
    public class EntityFieldType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int MinCellSize { get; set; }
        public int MaxCellSize { get; set; }
        public int DefaultCellSize { get; set; }
        public bool MyProperty { get; set; }
    }
}
