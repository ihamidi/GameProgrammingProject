using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionFollowBehavior : MinionController
{

    public float speed;
    public float distance;
    private Transform player;

    // start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (Vector2.Distance(animator.transform.position, player.position) < distance)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isIdle", true);
        }
    }

    // stops
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
