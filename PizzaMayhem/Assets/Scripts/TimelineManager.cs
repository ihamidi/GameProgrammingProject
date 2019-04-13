using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AnimationModule;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{ 
private bool fix;
    public Animator animator;
    public RuntimeAnimatorController playerAnim;
    public PlayableDirector director;
    // Start is called before the first frame update
    void onEnable()
    {
    playerAnim = animator.RuntimeAnimatorController;
    animator.RuntimeAnimatorController = null;  
    }

    // Update is called once per frame
    void Update()
    {
        if(director.state != PlayState.Playing && !fix)
    {
        fix = true;
        animator.RuntimeAnimatorController = playerAnim;
    }
   }
  }