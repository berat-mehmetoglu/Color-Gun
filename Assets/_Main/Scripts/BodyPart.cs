using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private MortyColor _color;
    private NPCEvents _npcEvents;

    // Start is called before the first frame update
    void Start()
    {
        _npcEvents = GetComponentInParent<NPCEvents>();
    }

    public void OnShoot(MortyColor color)
    {
        if (color == _color)
        {
            _npcEvents.InvokeNPCDeath();
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
