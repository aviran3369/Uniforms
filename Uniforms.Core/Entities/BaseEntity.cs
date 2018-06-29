using System;
using System.Collections.Generic;
using System.Text;

namespace Uniforms.Core.Entities
{
    /// <summary>
    /// Represent base object with default properties of every entity / custom entity.
    /// </summary>
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int Status { get; set; }
    }
}
