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
