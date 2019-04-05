using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFacing : PizzaBoyAC
{
    public Sprite back;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        sr.sprite = back;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ((Input.GetKey(KeyCode.LeftArrow))|| Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isFront", true);
        }
        else
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
        }

    }
}
