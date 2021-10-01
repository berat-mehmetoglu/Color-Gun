using UnityEngine;
using VP.Nest.UI;
using VP.Nest.Utilities;

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

        private Gun _gun;

        private void Awake()
        {
            _gun = GetComponent<Gun>();
        }

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
            
            ShootBullet(rayTarget.forward);

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

        private void ShootBullet(Vector3 direction)
        {
            CameraShake.Instance.Shake(0.5f,0.2f);
            GunAnimation.Instance.DoAnimation();
            
            switch (_gun.ColorType)
            {
                case ColorType.Red:
                    var obj1= AmmoCreator.Instance.CreateRed();
                    obj1.GetComponent<Rigidbody>().velocity = direction * 100f;
                    break;
                case ColorType.Yellow:
                    var obj2 = AmmoCreator.Instance.CreateYellow();
                    obj2.GetComponent<Rigidbody>().velocity = direction * 100f;
                    break;
                case ColorType.Blue:
                    var obj3 = AmmoCreator.Instance.CreateBlue();
                    obj3.GetComponent<Rigidbody>().velocity = direction * 100f;
                  
                    break;
                case ColorType.Orange:
                    var obj4 = AmmoCreator.Instance.CreateOrange();
                    obj4.GetComponent<Rigidbody>().velocity = direction * 100f;
                    break;
                case ColorType.Purple:
                    var obj5 = AmmoCreator.Instance.CreatePurple();
                    obj5.GetComponent<Rigidbody>().velocity = direction * 100f;
                    break;
               
            }
        }
    }
}