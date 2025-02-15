using UnityEngine;

namespace Lesson
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private float _health = 3.0f;
        
        private bool _isAlive = true;
        public bool CanTakeDamage(float damage)
        {
            if (!_isAlive)
            {
                return false;
            }

            _health -= damage;

            if (_health <= 0)
            {
                _isAlive = false;
                return false;
            }
            
            return true;
        }
    }
}