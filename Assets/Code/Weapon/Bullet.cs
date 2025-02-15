using Unity.VisualScripting;
using UnityEngine;

namespace Lesson
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage = 1.0f; 
        
        private Rigidbody _rigidbody;

        private float _force = 3.0f;

        public float Force
        {
            get
            {
                if (_force < 0)
                {
                    return _force;    
                }

                return _force;
            }
            set
            {
                if (!IsActive)
                {
                    _force = 0;
                    return;
                }

                _force = value;
            }
        }
        public bool IsActive { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnBecameInvisible()
        {
            if (!IsActive)
            {
                return;
            }
            
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
            if (other.collider.TryGetComponent(out HealthController healthController))
            {
                if (healthController.CanTakeDamage(_damage))
                {
                    return;
                }

                if (!other.collider.TryGetComponent(out Rigidbody rigidbody))
                {
                    rigidbody = other.collider.AddComponent<Rigidbody>();
                }
                rigidbody.AddForce(_rigidbody.velocity * _force, ForceMode.Impulse);
            }
            
        }
        

        public void Sleep()
        {
            _rigidbody.Sleep();
            gameObject.SetActive(false);
            IsActive = false;
        }

        public void Run(Vector3 path, Vector3 startPosition)
        {
            transform.position = startPosition;
            gameObject.SetActive(true);
            _rigidbody.WakeUp();
            _rigidbody.AddForce(path);
            IsActive = true;
        }
    }
}