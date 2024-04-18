using System;
using System.Collections;
using Assets.Scripts.Infrastructure.Destroyers;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Projectiles;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Pools
{
    public class ProjectilesPool : IPool<ProjectileBehaviour>
    {
        private readonly ProjectileType _projectileType;

        private readonly IProjectileFactory _projectileFactory;
        private readonly IProjectileDestroyer _projectileDestroyer;

        private readonly Func<ProjectileBehaviour> _createFunc;
        private readonly Action<ProjectileBehaviour> _actionOnRelease;
        private readonly Action<ProjectileBehaviour> _actionOnGet;
        private readonly Action<ProjectileBehaviour> _actionOnDestroy;
        private readonly ObjectPool<ProjectileBehaviour> _objectPool;

        public ProjectilesPool(ProjectileType projectileType, IProjectileFactory projectileFactory, IProjectileDestroyer projectileDestroyer)
        {
            _projectileType = projectileType;
            _projectileFactory = projectileFactory;
            _projectileDestroyer = projectileDestroyer;

            _createFunc = createFunc;
            _actionOnRelease = actionOnRelease;
            _actionOnGet = actionOnGet;
            _actionOnDestroy = actionOnDestroy;


            _objectPool = new ObjectPool<ProjectileBehaviour>(
                _createFunc,
                actionOnRelease: _actionOnRelease,
                actionOnDestroy: _actionOnDestroy,
                actionOnGet: _actionOnGet,
                defaultCapacity: 10,
                maxSize: 100
                );
        }


        public ProjectileBehaviour Get()
        {
            return _objectPool.Get();
        }

        public void Release(ProjectileBehaviour element)
        {
            _objectPool.Release(element);
        }

        private ProjectileBehaviour createFunc()
        {
            ProjectileBehaviour projectile = _projectileFactory.CreateProjectile(_projectileType, Vector3.zero, 0);
            return projectile;
        }

        private void actionOnRelease(ProjectileBehaviour projectile)
        {
            projectile.ResetBehaviour();
            projectile.gameObject.SetActive(false);
        }

        private void actionOnGet(ProjectileBehaviour projectile)
        {
            projectile.gameObject.SetActive(true);
        }

        private void actionOnDestroy(ProjectileBehaviour projectile)
        {
            _projectileDestroyer.Destroy(projectile);
        }

        public void Clear()
        {
            _objectPool.Clear();
        }
    }
}