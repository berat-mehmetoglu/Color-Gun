using System;
using UnityEngine;
using VP.Nest.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;

    private void Start()
    {
        UIManager.Instance.InGameUI.FillBar.SetupFillBar(health);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("qwe");
            SetHealth();
        }
    }

    public void SetHealth()
    {
        health -= 10f;
        
        UIManager.Instance.InGameUI.FillBar.SetFillBar(health);
        
    }
}
