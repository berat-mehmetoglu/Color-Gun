using System;
using System.Collections;
using System.Collections.Generic;
using _Main.Scripts.GamePlay;
using UnityEngine;
using Random = System.Random;

public class NPCController : MonoBehaviour
{
    [SerializeField] public List<Renderer> _eyes;
    [SerializeField] private List<Material> _colors;
    public Dictionary<Material, MortyColor> _mortyDic = new Dictionary<Material, MortyColor>();
    private Transform _targetTransform;
    private NPCEvents _npcEvents;
    public MortyState _mortyState;
    private int _deathPartCount=0;
    private Renderer _npcRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _npcRenderer = GetComponentInChildren<NPCRenderer>().GetComponent<Renderer>();
        _targetTransform = Gun.Instance.transform;
        _npcEvents = GetComponent<NPCEvents>();
        _npcEvents.Death += OnDeathPart;
        
        for (int i = 0; i < _colors.Count; i++)
        {
            _colors[i] = new Material(_colors[i]);
        }
        
        Material[] c = new[]
        {
            _colors[UnityEngine.Random.Range(0, _colors.Count)], _colors[UnityEngine.Random.Range(0, _colors.Count)]
            , _colors[UnityEngine.Random.Range(0, _colors.Count)], _colors[UnityEngine.Random.Range(0, _colors.Count)]
            , _colors[UnityEngine.Random.Range(0, _colors.Count)]
        };

        for (int i = 0; i < 2; i++)
        {
            _eyes[i].material = c[i];
        }

        _npcRenderer.materials = c;
        
        _mortyDic.Add(_colors[0], MortyColor.Red);
        _mortyDic.Add(_colors[1], MortyColor.Blue);
        _mortyDic.Add(_colors[2], MortyColor.Orange);
        _mortyDic.Add(_colors[3], MortyColor.Yellow);
        _mortyDic.Add(_colors[4], MortyColor.Purple);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.TryGetComponent(out Gun _))
        {
            _npcEvents.InvokeFight();
            _mortyState = MortyState.Fight;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        
        if (other.TryGetComponent(out Gun _))
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
