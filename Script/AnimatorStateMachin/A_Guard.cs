using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Guard : StateMachineBehaviour
{
    private PlayerController playerController;
    private P_Status stateMachine;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController = animator.GetComponent<PlayerController>();
        stateMachine = animator.GetComponent<P_Status>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController.moveSpd = 0f;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateMachine.PS = P_Status.PLAYERSTATUS.IDLE;
    }
}
