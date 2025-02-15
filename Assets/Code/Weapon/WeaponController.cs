using UnityEngine;

namespace Lesson
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _weapon.Fire();
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _weapon.Recharge();
            }
        }
    }
}
