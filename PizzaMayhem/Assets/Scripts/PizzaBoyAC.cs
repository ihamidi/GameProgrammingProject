using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBoyAC : StateMachineBehaviour
{
    public Transform pizzaBoy;
    public Rigidbody2D rb;
    public float speed;
    public Vector2 moveSpeed;
    public SpriteRenderer sr;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pizzaBoy = animator.gameObject.transform;
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        sr = animator.gameObject.GetComponent<SpriteRenderer>();
        speed = 7;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveSpeed = moveInput.normalized * speed;
    }
}
