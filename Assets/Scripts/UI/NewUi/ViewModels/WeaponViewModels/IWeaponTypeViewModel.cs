using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.NewUi.WeaponViewModels
{
    public interface IWeaponTypeViewModel
    {
        public WeaponType WeaponType { get; set; }
    }
}
