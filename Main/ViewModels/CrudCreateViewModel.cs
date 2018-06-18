using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DemonTaleManager.Web.ViewModels
{
    public class CrudViewModel
    {
        public Type EntityType { get; set; }
        public List<Dictionary<int, List<object>>> EntitesPropertiesValues { get; set; }
        public IEnumerable<string> EntityPropertiesName { get; set; }
    }
}