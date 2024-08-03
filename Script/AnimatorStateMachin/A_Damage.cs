using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Damage : StateMachineBehaviour
{

    private PlayerController playerController;
    private P_Status stateMachine;

    public static bool DamageBack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController = animator.GetComponent<PlayerController>();
        stateMachine = animator.GetComponent<P_Status>();

        playerController.moveSpd = 0f;
        playerController.inputInvalid = true;
        DamageBack = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateMachine.PS = P_Status.PLAYERSTATUS.DAMAGE;
        A_Attack.MotionMove = false;
        A_Attack.MotionUp = false;
        A_Attack.FastForward = false;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateMachine.PS = P_Status.PLAYERSTATUS.IDLE;
        playerController.inputInvalid = false;
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (DamageBack == true)
        {
            animator.transform.position -= animator.transform.forward.normalized * 1 * Time.deltaTime;
        }
    }
}
