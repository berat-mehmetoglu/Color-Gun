using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] private Material _dissolve;
    
    private List<Collider> _colliders = new List<Collider>();

    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    private NPCEvents _npcEvents;

    // Start is called before the first frame update
    void Start()
    {
        _colliders = GetComponentsInChildren<Collider>().ToList();
        _rigidbodies = GetComponentsInChildren<Rigidbody>().ToList();

        foreach (var VARIABLE in _colliders)
        {
            VARIABLE.isTrigger = true;
        }
        
        foreach (var VARIABLE in _rigidbodies)
        {
            VARIABLE.isKinematic = true;
        }

        _npcEvents = GetComponentInParent<NPCEvents>();
        _npcEvents.Death += OnDeath;
    }

    void OnDeath()
    {
        foreach (var VARIABLE in _colliders)
        {
            VARIABLE.isTrigger = false;
        }
        
        foreach (var VARIABLE in _rigidbodies)
        {
            VARIABLE.isKinematic = false;
        }

        Material newMat = new Material(_dissolve);
        foreach (var VARIABLE in GetComponentsInChildren<Renderer>())
        {
            VARIABLE.material = newMat;
        }

        float cutoff = 0;
        DOTween.To(() => cutoff, x => newMat.SetFloat("_cutoff",x), 1, 1).SetDelay(5).OnComplete((() =>
        {
            //_npcEvents.gameObject.SetActive(false);
        }));
    }
}
