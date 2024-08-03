using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class A_Attack : StateMachineBehaviour
{
    private P_Status stateMachine;
    private PlayerController playerController;

    public static bool MotionMove, MotionUp, FastForward, MoveStp, CancStp, SlowStp;
    float forward = 0.4f, fastforward = 10.0f, up = 2.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateMachine = animator.GetComponent<P_Status>();
        playerController = animator.GetComponent<PlayerController>();
        stateMachine.PS = P_Status.PLAYERSTATUS.ATTACK;
        playerController.attackRotation = true;
        MotionMove = true;

        playerController.motionCancel = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (MotionMove == true) animator.transform.position +=
        //          animator.transform.forward.normalized * forward * Time.deltaTime;

        //if (FastForward == true && MoveStp == false) animator.transform.position +=
        //         animator.transform.forward.normalized * fastforward * Time.deltaTime;

        //if (MotionUp == true && MoveStp == false) animator.transform.position +=
        //         animator.transform.up.normalized * up * Time.deltaTime;
    }

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        playerController = animator.GetComponent<PlayerController>();
        playerController.nomalRotation = true;
        playerController.motionCancel = false;
        playerController.moveCancel = true;
    }

    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        playerController.inputInvalid = false;
        playerController.motionCancel = false;
        playerController.moveCancel = false;
        animator.speed = 1.0f;
    }
}
