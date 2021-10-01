using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private Renderer _rend;
    [SerializeField] private int _konum;
    
    private NPCEvents _npcEvents;
    private NPCController _controller;

    private bool _deathPart=false;
    // Start is called before the first frame update
    void Start()
    {
        _npcEvents = GetComponentInParent<NPCEvents>();
        _controller = GetComponentInParent<NPCController>();
        print(_controller);
        _rend = _controller.GetComponentInChildren<NPCRenderer>().GetComponent<Renderer>();
    }

    public void OnShoot(MortyColor color)
    {
        _npcEvents.InvokeNPCDeath();
        Color c = Color.black;
        c.a = 0;
        _rend.materials[_konum].color = c;
    }
}

public enum MortyColor
{
    Red,
    Yellow,
    Blue,
    Orange,
    Purple
}

/*
 *if (color == _controller._mortyDic[(int)_rend.materials[_konum].color.r*255])
        {
            foreach (var VARIABLE in _controller._eyes)
            {
                print(color);
                print(_controller._mortyDic[(int)VARIABLE.material.color.r*255]);
                if (color == _controller._mortyDic[(int)VARIABLE.material.color.r*255])
                {
                    _npcEvents.InvokeNPCDeath();
                    _deathPart = true;
                    VARIABLE.enabled = false;
                    Color c = Color.black;
                    c.a = 0;
                    _rend.materials[_konum].color = c;
                    print("deatgh");
                    break;
                }
            }
        }
*/