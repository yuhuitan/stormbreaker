using UnityEngine;
using System;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition transition;
    public float timeout;
    public bool randomAttack;
    public bool skillCoolDown = true;
    public bool fixedInterval = true;
    public float intervalSecond;
    public int stateIndex;

    private string result;
    private int index;
    private string value;
    private bool decisionSucceded;

    [HideInInspector] public float storedTime = -1;

    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(StateController controller)
    {
        // TODO: Modify here to make the healing skill independent of the skillCoolDown time
        int totalActions = actions.Length;
        if (skillCoolDown)
        {
            if (storedTime < 0 || controller.CheckIfCoolDown(storedTime, intervalSecond))
            {
                storedTime = controller.stateTimeElapsed;
                if (randomAttack)
                {
                    int actionSelected = UnityEngine.Random.Range(0, totalActions);
                    actions[actionSelected].Act(controller);
                }
                else
                {
                    for (int i = 0; i < totalActions; i++) actions[i].Act(controller);
                }
            }
        }
        else
        {
            for (int i = 0; i < totalActions; i++) actions[i].Act(controller);
        }

    }

    private void CheckTransitions(StateController controller)
    {
        // initialize empty string
        result = "";
        for (int j = 0; j < transition.decisions.Length; j++)
        {
            Decision decision = transition.decisions[j];
            decisionSucceded = decision.Decide(controller);
            // if true, value = "1", else value = "false", then concatenate it to the result, result is in binary string
            value = decisionSucceded ? "1" : "0";
            result += value;
        }
        //Debug.Log("result:"+result);

        // convert result to integer, which is the index for the states list in transition
        index = Convert.ToInt32(result, 2);

        // transit to the corresponding state
        controller.TransitionToState(transition.states[index]);
    }
}
