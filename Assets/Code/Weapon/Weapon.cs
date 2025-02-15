using TMPro.EditorUtilities;
using UnityEngine;

namespace Lesson
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _barrel;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _countInClip;
        [SerializeField] private float _force;
        [SerializeField] private float _shotDelay;

        private Transform _bulletRoot;
        private Bullet[] _bullets;
        
        public void Start()
        {
            _bulletRoot = new GameObject("BulletRoot").transform;
            Recharge();
        }
        
        public void Fire()
        {
            
        }

        public void Recharge()
        {
            _bullets = new Bullet[_countInClip];
            for (int i = 0; i < _countInClip; i++)
            {
                Bullet bullet = Instantiate(_bulletPrefab, _bulletRoot);
                bullet.Sleep();
                _bullets[i] = bullet;
            }
        }
    }
}