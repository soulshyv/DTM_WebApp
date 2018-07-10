using Autofac;
using DTM.Core.Repositories;
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

        private DemonRepository _demonRepository;
        public DemonRepository DemonRepository => _demonRepository ?? (_demonRepository = Scope.Resolve<DemonRepository>());

        private DemonPersoRepository _demonPersoRepository;
        public DemonPersoRepository DemonPersoRepository => _demonPersoRepository ?? (_demonPersoRepository = Scope.Resolve<DemonPersoRepository>());

        private DonRepository _donRepository;
        public DonRepository DonRepository => _donRepository ?? (_donRepository = Scope.Resolve<DonRepository>());

        private DonPersoRepository _donPersoRepository;
        public DonPersoRepository DonPersoRepository => _donPersoRepository ?? (_donPersoRepository = Scope.Resolve<DonPersoRepository>());

        private ElementRepository _elementRepository;
        public ElementRepository ElementRepository => _elementRepository ?? (_elementRepository = Scope.Resolve<ElementRepository>());

        private ElementPersoRepository _elementPersoRepository;
        public ElementPersoRepository ElementPersoRepository => _elementPersoRepository ?? (_elementPersoRepository = Scope.Resolve<ElementPersoRepository>());

        private InventaireRepository _inventaireRepository;
        public InventaireRepository InventaireRepository => _inventaireRepository ?? (_inventaireRepository = Scope.Resolve<InventaireRepository>());

        private ItemRepository _itemRepository;
        public ItemRepository ItemRepository => _itemRepository ?? (_itemRepository = Scope.Resolve<ItemRepository>());

        private MetierRepository _metierRepository;
        public MetierRepository MetierRepository => _metierRepository ?? (_metierRepository = Scope.Resolve<MetierRepository>());

        private MetierPersoRepository _metierPersoRepository;
        public MetierPersoRepository MetierPersoRepository => _metierPersoRepository ?? (_metierPersoRepository = Scope.Resolve<MetierPersoRepository>());

        private PassifRepository _passifcRepository;
        public PassifRepository PassifRepository => _passifcRepository ?? (_passifcRepository = Scope.Resolve<PassifRepository>());

        private PassifPersoRepository _passifPersoRepository;
        public PassifPersoRepository PassifPersoRepository => _passifPersoRepository ?? (_passifPersoRepository = Scope.Resolve<PassifPersoRepository>());

        private PassifDemonRepository _passifDemonRepository;
        public PassifDemonRepository PassifDemonRepository => _passifDemonRepository ?? (_passifDemonRepository = Scope.Resolve<PassifDemonRepository>());

        private PersoRepository _persoRepository;
        public PersoRepository PersoRepository => _persoRepository ?? (_persoRepository = Scope.Resolve<PersoRepository>());

        private SkillRepository _skillRepository;
        public SkillRepository SkillRepository => _skillRepository ?? (_skillRepository = Scope.Resolve<SkillRepository>());

        private SkillPersoRepository _skillPersoRepository;
        public SkillPersoRepository SkillPersoRepository => _skillPersoRepository ?? (_skillPersoRepository = Scope.Resolve<SkillPersoRepository>());

        private UserRepository _userRepository;
        public UserRepository UserRepository => _userRepository ?? (_userRepository = Scope.Resolve<UserRepository>());
    }
}