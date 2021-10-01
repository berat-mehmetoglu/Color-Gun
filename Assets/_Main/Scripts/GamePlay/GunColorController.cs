using _Main.Scripts.GamePlay;
using TMPro;
using UnityEngine;

public class GunColorController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _textMeshPros;
    [SerializeField] private Color32[] _color32s;
    private Gun _gun;
    public Material mat;
    private void Awake()
    {
        _gun = GetComponent<Gun>();
        _gun.MortyColor = MortyColor.Red;
        _textMeshPros[0].color = Color.green;
        mat.color = _color32s[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _gun.MortyColor = MortyColor.Red;
            mat.color = _color32s[0];
            _textMeshPros[0].color = Color.green;
            _textMeshPros[1].color = Color.white;
            _textMeshPros[2].color = Color.white;
            _textMeshPros[3].color = Color.white;
            _textMeshPros[4].color = Color.white;
            AnimatorController.Instance.LeftAnim();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mat.color = _color32s[1];
            _gun.MortyColor = MortyColor.Yellow;
            _textMeshPros[0].color = Color.white;
            _textMeshPros[1].color = Color.green;
            _textMeshPros[2].color = Color.white;
            _textMeshPros[3].color = Color.white;
            _textMeshPros[4].color = Color.white;
            AnimatorController.Instance.LeftAnim();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mat.color = _color32s[2];
            _gun.MortyColor = MortyColor.Blue;
            _textMeshPros[0].color = Color.white;
            _textMeshPros[1].color = Color.white;
            _textMeshPros[2].color = Color.green;
            _textMeshPros[3].color = Color.white;
            _textMeshPros[4].color = Color.white;
            AnimatorController.Instance.LeftAnim();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mat.color = _color32s[3];
            _gun.MortyColor = MortyColor.Orange;
            _textMeshPros[0].color = Color.white;
            _textMeshPros[1].color = Color.white;
            _textMeshPros[2].color = Color.white;
            _textMeshPros[3].color = Color.green;
            _textMeshPros[4].color = Color.white;
            AnimatorController.Instance.LeftAnim();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            mat.color = _color32s[4];
            _gun.MortyColor = MortyColor.Purple;
            _textMeshPros[0].color = Color.white;
            _textMeshPros[1].color = Color.white;
            _textMeshPros[2].color = Color.white;
            _textMeshPros[3].color = Color.white;
            _textMeshPros[4].color = Color.green;
            AnimatorController.Instance.LeftAnim();
        }
    }
}
