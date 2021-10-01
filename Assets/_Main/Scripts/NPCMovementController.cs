using System.Collections;
using System.Collections.Generic;
using _Main.Scripts.GamePlay;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovementController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _targetTransform;
    private NPCEvents _npcEvents;
    private float _movementSpeed=3.5F;
    private NPCController _npcController;

    // Start is called before the first frame update
    void Awake()
    {
        _targetTransform = Gun.Instance.transform;
        _npcEvents = GetComponentInParent<NPCEvents>();
        _npcEvents.Fight += OnFight;
        _npcEvents.Death += OnDeath;
        _npcEvents.Run += OnRun;
        _npcController = GetComponent<NPCController>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void OnRun()
    {
        _movementSpeed = 3.5f;
    }

    void OnFight()
    {
        _movementSpeed = 0;
    }
    
    void OnDeath()
    {
        _movementSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_npcController._mortyState == MortyState.Run)
        {
            _agent.SetDestination(_targetTransform.position);
        }

        _agent.speed = _movementSpeed;
    }
}
