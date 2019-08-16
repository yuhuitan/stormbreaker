using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public State currentState;
    public State remainState;

    //[HideInInspector] public Health healthObject;
    [HideInInspector] public Boss boss;
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public Animator anim;
    [HideInInspector] public int previousState;
    [HideInInspector] public StateController instance;

    void Start()
    {
       // healthObject = GetComponent<Health>();
       // TODO: maybe replace boss with health
        boss = GetComponent<Boss>();
        //anim = GetComponent<Animator>();
        anim = GetComponent<Animator>();
        currentState.storedTime = -1;
        Debug.Log(anim);
        instance = this;
    }

    public void TransitionToState(State nextState)
    {
        if (nextState == remainState) return;
        currentState.storedTime = -1;
        previousState = currentState.stateIndex;
        currentState = nextState;
        if (boss.bossId == 3)
        {
            if (previousState == 4 && currentState.stateIndex != 0)
            {
                anim.SetBool("frenzystate", false);
            }

            if (currentState.stateIndex == 4)
            {
                anim.SetTrigger("frenzytransform");
                anim.SetBool("frenzystate", true);
            }
        }
        boss.currentState = currentState.stateIndex;
        Debug.Log(stateTimeElapsed);
        Debug.Log("current state: " + currentState);
        OnExitState();
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return stateTimeElapsed >= duration;
    }

    public int SelectLocationToAttack(bool random, int totalLocations, int current_index)
    {
        if (random)
        {
            current_index = Random.Range(1, totalLocations+1);
        }
        else
        {
            if (current_index < 0)
            {
                current_index = 1;
            }
            else if (current_index >= 1)
            {
                current_index = current_index % totalLocations;
                current_index += 1;
            }
        }
        return current_index;
    }

    public bool CheckIfCoolDown(float storedTime, float timeInterval)
    {
        if (stateTimeElapsed - storedTime >= timeInterval)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnExitState()
    {
        stateTimeElapsed = 0;
        currentState.storedTime = -1;
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

}
