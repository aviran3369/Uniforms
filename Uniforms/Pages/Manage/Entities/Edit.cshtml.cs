using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Uniforms.Core.Entities;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Uniforms.ViewModels;
using Uniforms.Core.Utilities;

namespace Uniforms.Pages.Manage.Entities
{
    public class EditModel : PageModel
    {
        public EntityModel Entity { get; set; }

        public void OnGet()
        {
            Entity = new EntityModel()
            {
                Id  = UniqueKeyGenerator.NewKey()
            };
        }

        public void OnPost(EntityModel entity)
        {
            DynamicEntity d = DynamicEntity.CreateFromObject(entity);
            
        }
    }
}
