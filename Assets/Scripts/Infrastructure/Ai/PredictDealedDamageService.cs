using Assets.Scripts.Entities;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Ai
{
    public class PredictDealedDamageService : IPredictDealedDamageService
    {
        private readonly Dictionary<IDamagable, float> _damagePredictions;
        private readonly ISpaceShipRegistry _spaceShipRegistry;

        public PredictDealedDamageService(ISpaceShipRegistry spaceShipRegistry)
        {
            _spaceShipRegistry = spaceShipRegistry;
            _damagePredictions = new ();

            _spaceShipRegistry.OnSpaceShipRegistered += OnSpaceShipRegistered;
            _spaceShipRegistry.OnSpaceShipUnregistered += OnSpaceShipUnregistered;
        }

        public float PredictDealedDamage(ISpaceShip damagable)
        {
            return _damagePredictions[damagable];
        }

        private void OnSpaceShipRegistered(ISpaceShip spaceShip)
        {
            spaceShip.OnAttack += OnAttack;
            _damagePredictions.Add(spaceShip, 0);
        }

        private void OnSpaceShipUnregistered(ISpaceShip spaceShip)
        {
            spaceShip.OnAttack -= OnAttack;
            _damagePredictions.Remove(spaceShip);
        }

        private void OnAttack(object sender, AttackEventArgs e)
        {
            _damagePredictions[e.Target] += e.Damage;
        }
    }
}
