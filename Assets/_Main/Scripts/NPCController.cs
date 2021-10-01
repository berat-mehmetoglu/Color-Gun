using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Transform _targetTransform;
    private NPCEvents _npcEvents;
    public MortyState _mortyState;
    private int _deathPartCount=0;

    // Start is called before the first frame update
    void Start()
    {
        _targetTransform = DummyPlayer.Instance.transform;
        _npcEvents = GetComponent<NPCEvents>();
        _npcEvents.Death += OnDeathPart;
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.TryGetComponent(out DummyPlayer _))
        {
            _npcEvents.InvokeFight();
            _mortyState = MortyState.Fight;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        
        if (other.TryGetComponent(out DummyPlayer _))
        {
            _npcEvents.InvokeRun();
            _mortyState = MortyState.Run;
        }
    }

    [ContextMenu("Death")]
    public void OnDeathPart()
    {
        _deathPartCount++;
        if (_deathPartCount == 2)
        {
            _npcEvents.InvokeDeath();
        }
    }


    void OnDeath()
    {
        
    }
}

public enum MortyState
{
    Walk,
    Run,
    Fight
}
