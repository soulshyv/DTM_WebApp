using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace DemonTaleManager.Web.Views.Characters
{
    public abstract class DtmControllerBase : Controller
    {
        /// <inheritdoc />
        protected DtmControllerBase(ILifetimeScope scope)
        {
            Scope = scope;
        }

        public ILifetimeScope Scope { get; }
    }
}