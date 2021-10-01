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
    }

    public void OnShoot(MortyColor color)
    {
        if (_deathPart)
        {
            return;
        }
        
        if (color == _controller._mortyDic[_rend.materials[_konum]])
        {
            foreach (var VARIABLE in _controller._eyes)
            {
                if (color == _controller._mortyDic[VARIABLE.material])
                {
                    _npcEvents.InvokeNPCDeath();
                    _deathPart = true;
                    VARIABLE.enabled = false;
                    Color c = Color.black;
                    c.a = 0;
                    _rend.materials[_konum].color = c;
                    break;
                }
            }
        }
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