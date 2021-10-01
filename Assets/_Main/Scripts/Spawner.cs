using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _morty;
    [SerializeField] private int number;
    
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(_morty, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
