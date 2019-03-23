using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionController : StateMachineBehaviour
{
    NavMeshAgent agent;
    GameObject minion;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        minion = animator.gameObject;
        agent = animator.gameObject.GetComponent<NavMeshAgent>();
    }

    protected void setDestination(Vector2 position)
    {
        agent.SetDestination(position);
    }

}
