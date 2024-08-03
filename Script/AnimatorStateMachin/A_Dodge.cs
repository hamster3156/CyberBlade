using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Dodge : StateMachineBehaviour
{
    private PlayerController playerController;
    private P_Status stateMachine;
    public static bool DodgeMove = false;
    public float DodgSpd = 2.5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController = animator.GetComponent<PlayerController>();
        stateMachine = animator.GetComponent<P_Status>();
        playerController.nomalRotation = true;
        playerController.motionCancel = false;
        DodgeMove = true;
    }

    // ñàÉtÉåÅ[ÉÄé¿çs
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateMachine.PS = P_Status.PLAYERSTATUS.DODGE;
        playerController.inputInvalid = true;
        playerController.moveSpd = 0f;
        stateMachine.PS = P_Status.PLAYERSTATUS.DODGE;

        A_Attack.MotionMove = false;
        A_Attack.MotionUp = false;
    }   

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateMachine.PS = P_Status.PLAYERSTATUS.IDLE;
        playerController.inputInvalid = false;
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (DodgeMove == true)
        {
            playerController.motionCancel = false;
            animator.transform.position += animator.transform.forward.normalized * DodgSpd * Time.deltaTime;
        }
    }

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        playerController = animator.GetComponent<PlayerController>();
    }
}
