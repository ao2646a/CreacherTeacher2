using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
    Roaming,
    Idle,
    Attack
}

public class AI : MonoBehaviour
{
    private AIState state;
    
    // Start is called before the first frame update
    void Start()
    {
        state = AIState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case AIState.Roaming:
                break;
            case AIState.Idle:
                IdleBehavior();
                break;
            case AIState.Attack:
                break;
        }
    }

    void IdleBehavior() {
        state = AIState.Roaming;
    }

    public void ChangeToRoaming()
    {
        state = AIState.Roaming;
    }

}
