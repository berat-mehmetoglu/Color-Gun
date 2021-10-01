using UnityEngine;
using VP.Nest.UI;

namespace _Main.Scripts.GamePlay
{
    public class GunRaycaster : MonoBehaviour
    {
        [SerializeField] private Transform rayTarget;
        
        [SerializeField] private float reloadTime;
        
        private bool _reload;
        private bool _haveShoot;

        private float _currentTime;

        private bool _haveRay;
        
        private void OnEnable()
        {
            UIManager.Instance.InGameUI.OnLevelStart += () =>
            {
                _haveRay = true;
            };
        }
        
        public void Update()
        {
            if(!_haveRay) return;
            
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
            if(!_haveRay) return;   
            
            //Execute Shoot
            if (_haveShoot)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            
            _haveShoot = false;
            
            var ray = new Ray (rayTarget.position, rayTarget.forward);

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