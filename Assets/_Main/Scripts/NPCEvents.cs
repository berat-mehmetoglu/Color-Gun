using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCEvents : MonoBehaviour
{
    public event Action<GameObject> BreakPot = delegate(GameObject e) {  };
    
    public event Action<GameObject, int> Passed = delegate(GameObject e, int r) {  };
    
    public event Action Fight = delegate {  };
    
    public event Action Run = delegate {  };
    
    public event Action Death = delegate {  };
    
    public event Action NPCDeath = delegate {  };
    
    public event Action PlayerDied = delegate {  };
    public event Action VictoryStart = delegate {  };
    
    public event Action EndGameEnd = delegate {  };
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnSuccess()
    {
        
    }

    public void InvokePlayerDied()
    {
        PlayerDied();
    }
    public void InvokePassed(GameObject e, int r)
    {
        Passed(e,r);
    }
    
    public void InvokeFight()
    {
        Fight();
    }
    
    public void InvokeRun()
    {
        Run();
    }
    
    public void InvokeDeath()
    {
        Death();
    }
    public void InvokeNPCDeath()
    {
        NPCDeath();
    }
    public void InvokeEndGameEnd()
    {
        EndGameEnd();
    }
}
