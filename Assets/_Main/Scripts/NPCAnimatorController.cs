using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimatorController : MonoBehaviour
{
    private Animator _anim;
    private NPCEvents _npcEvents;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _npcEvents = GetComponentInParent<NPCEvents>();
        _npcEvents.Fight += OnFight;
        _npcEvents.Death += OnDeath;
        _npcEvents.Run += OnRun;
    }

    void OnFight()
    {
        _anim.SetTrigger("Fight");
    }
    
    void OnDeath()
    {
        _anim.enabled = false;
        _anim.SetTrigger("Death");
    }
    
    void OnRun()
    {
        _anim.SetTrigger("Run");
    }
}

public enum MortyAnim
{
    Death,
    Run,
    Shoot
}

/*
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
                    break;
                }
            }
        }
    }
}

public enum MortyColor
{
    Blue,
    Purple,
    Yellow,
    Green,
    Red
}

 */
