using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararseMBehaviour : StateMachineBehaviour
{
    //Vector3 posPreserve;
    PlayerControlCC_2 controller;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<PlayerControlCC_2>().active = false; // queda solo escuchando si se sienta
        //posPreserve = animator.transform.position;
        
        controller = animator.GetComponent<PlayerControlCC_2>();
        animator.SetBool("isSitting", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<PlayerControlCC_2>()

        controller.horizontal = 0;
        controller.vertical = 0;
        animator.SetBool("isSitting", false);
        controller.isSitting = false;
        //animator.transform.position = posPreserve;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.active = true; // reactivo movimiento
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
