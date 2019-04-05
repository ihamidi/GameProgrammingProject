using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontFacing : PizzaBoyAC
{
    bool faceRight;
    bool faceLeft;
    public Sprite front;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        faceRight = true;
        sr.sprite = front;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ((Input.GetKey(KeyCode.UpArrow)))
        {
            animator.SetBool("isBack", true);
        }
        else
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
        }
        
    }
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime);
        Flip();
    }

    private void Flip()
    {
        if ((faceRight && Input.GetKey(KeyCode.LeftArrow)))
        {
            faceLeft = true;
            faceRight = false;
            pizzaBoy.Rotate(0f, 180f, 0f);
        }
        if ((faceLeft && Input.GetKey(KeyCode.RightArrow)))
        {
            faceRight = true;
            faceLeft = false;
            pizzaBoy.Rotate(0f, 180f, 0f);
        }
    }
}
