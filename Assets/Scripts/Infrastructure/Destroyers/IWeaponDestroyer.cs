using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Entities.Weapons;

namespace Assets.Scripts.Infrastructure.Destroyers
{
    public interface IWeaponDestroyer
    {
        void Destroy(IWeapon weapon);
    }
}
