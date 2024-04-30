using UnityEngine;
using Zenject;

namespace Assets.Scripts.Entities.Projectiles.ProjectileBehaviours
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ColorPingPongBehaviour : MonoBehaviour, ITickable
    {
        [SerializeField] private Color _startColor = Color.white;
        [SerializeField] private Color _endColor = Color.white;
        [Tooltip("Time in seconds for one full ping-pong cycle")]
        [SerializeField] private float _period = 1f;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Tick()
        {
            var t = Mathf.PingPong(Time.time, _period) / _period;
            _spriteRenderer.color = Color.Lerp(_startColor, _endColor, t);
        }
    }
}