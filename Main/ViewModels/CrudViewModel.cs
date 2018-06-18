﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DemonTaleManager.Web.ViewModels
{
    public class CrudCreateViewModel
    {
        public Type EntityType { get; set; }
        public object Entity { get; set; }
    }
}