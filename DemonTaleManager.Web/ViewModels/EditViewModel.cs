using System;

namespace DemonTaleManager.Web.ViewModels
{
    public class EditViewModel
    {
        public Type EntityType { get; set; }
        public object Entity { get; set; }
        public int Id { get; set; }
    }
}