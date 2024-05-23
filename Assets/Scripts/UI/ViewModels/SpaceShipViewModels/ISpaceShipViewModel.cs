using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.ViewModels.SpaceShipViewModels
{
    public interface ISpaceShipViewModel
    {
        SpaceShipType SpaceShipType { get; set; }
    }
}
