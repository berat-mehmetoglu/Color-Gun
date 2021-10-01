using UnityEngine;

namespace _Main.Scripts.GamePlay
{
    public class GunRaycaster : MonoBehaviour
    {
        [SerializeField] private Transform shootTarget;
        
        [SerializeField] private float reloadTime;
        
        private bool _reload;
        private bool _haveShoot;

        private float _currentTime;
        
        public void Update()
        {
            //Shoot
            if (Input.GetMouseButtonDown(0) && !_reload)
            {
                _reload = true;
                _haveShoot = true;
            }

            //Reload Time
            if (_reload)
            {
                _currentTime += Time.deltaTime;

                if (_currentTime >= reloadTime)
                {
                    _reload = false;
                    _currentTime = 0f;
                }
            }
        }

        private void FixedUpdate()
        {
            //Execute Shoot
            if (_haveShoot)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _haveShoot = false;
            
            var ray = new Ray (shootTarget.position, shootTarget.forward);

            if (Physics.Raycast (ray, out var hit,Mathf.Infinity))
            {
                // if (hit.rigidbody.TryGetComponent(out Morty))
                // {
                //     //Execute morty collider
                // }
                
                 if (hit.rigidbody && hit.rigidbody.TryGetComponent(out Test test))
                {
                    //Execute morty collider
                    hit.rigidbody.AddForce(-hit.normal * 1000f);
                    Debug.Log(test.name);
                }
                
            }
            Debug.Log("Shoot");
        }
    }
}