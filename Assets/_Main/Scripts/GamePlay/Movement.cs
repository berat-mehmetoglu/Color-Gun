using System.Timers;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed; 
    private Rigidbody _rb;

    private int _left;
    private int _right;
    private int _up;
    private int _down;
    
   

    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
        if (Input.GetKey(KeyCode.A))
        {
            _left = 1;
        }
        else
        {
            _left = 0;
        }
       
        if (Input.GetKey(KeyCode.D))
        {
            _right = 1;
        }
        else
        {
            _right = 0;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            _up = 1;
        }
        else
        {
            _up = 0;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            _down = 1;
        }
        else
        {
            _down = 0;
        }
        
       
    }

    
    
    private void FixedUpdate()
    {
        _rb.velocity = (-transform.right * _left + transform.right * _right +
                        transform.forward * _up + (-transform.forward) * _down) *
                       (movementSpeed * Time.fixedDeltaTime);
    }
}
