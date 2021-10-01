using _Main.Scripts.GamePlay;
using TMPro;
using UnityEngine;

public class GunColorController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _textMeshPros;
    
    private Gun _gun;
    
    private void Awake()
    {
        _gun = GetComponent<Gun>();
        _gun.ColorType = ColorType.Red;
        _textMeshPros[0].color = Color.green;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _gun.ColorType = ColorType.Red;
            _textMeshPros[0].color = Color.green;
            _textMeshPros[1].color = Color.white;
            _textMeshPros[2].color = Color.white;
            _textMeshPros[3].color = Color.white;
            _textMeshPros[4].color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _gun.ColorType = ColorType.Yellow;
            _textMeshPros[0].color = Color.white;
            _textMeshPros[1].color = Color.green;
            _textMeshPros[2].color = Color.white;
            _textMeshPros[3].color = Color.white;
            _textMeshPros[4].color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _gun.ColorType = ColorType.Blue;
            _textMeshPros[0].color = Color.white;
            _textMeshPros[1].color = Color.white;
            _textMeshPros[2].color = Color.green;
            _textMeshPros[3].color = Color.white;
            _textMeshPros[4].color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _gun.ColorType = ColorType.Orange;
            _textMeshPros[0].color = Color.white;
            _textMeshPros[1].color = Color.white;
            _textMeshPros[2].color = Color.white;
            _textMeshPros[3].color = Color.green;
            _textMeshPros[4].color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _gun.ColorType = ColorType.Purple;
            _textMeshPros[0].color = Color.white;
            _textMeshPros[1].color = Color.white;
            _textMeshPros[2].color = Color.white;
            _textMeshPros[3].color = Color.white;
            _textMeshPros[4].color = Color.green;
        }
    }
}
