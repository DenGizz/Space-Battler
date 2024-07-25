using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Battles
{
    public class BattleTeam
    {
        public IEnumerable<ISpaceShip> Members => _members;

        public event Action<ISpaceShip> OnMemberAdded;
        public event Action<ISpaceShip> OnMemberRemoved;

        private readonly List<ISpaceShip> _members;

        public BattleTeam()
        {
            _members = new List<ISpaceShip>();
        }

        public void AddMember(ISpaceShip spaceShip)
        {
            _members.Add(spaceShip);
            OnMemberAdded?.Invoke(spaceShip);
        }

        public void RemoveMember(ISpaceShip spaceShip)
        {
            _members.Remove(spaceShip);
            OnMemberRemoved?.Invoke(spaceShip);
        }
    }
}
