using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_ComboManager : MonoBehaviour
{
    PlayerInput _attack, _specialAttack;

    private P_Status stateMachine;
    private Animator animator;
    private P_AnimatorManager animatorManager;
    private PlayerController playerController;

    public float timer, finishtimer, canceltimer;
    public bool inputInvalid, finishAttack, motionCancel;

    void Awake()
    {
        TryGetComponent(out _attack);
        TryGetComponent(out _specialAttack);

        stateMachine = GetComponent<P_Status>();
        animator = GetComponent<Animator>();
        animatorManager = GetComponent<P_AnimatorManager>();
        playerController = GetComponent<PlayerController>();
    }

    void OnEnable()
    {
        _attack.actions["Attack"].started += OnAttack;
        _specialAttack.actions["SpecialAttack"].started += OnSpecialAttack;
    }

    void OnDisable()
    {
        _attack.actions["Attack"].started -= OnAttack;
        _specialAttack.actions["SpecialAttack"].started -= OnSpecialAttack;
    }

    void FixedUpdate()
    {
        if (inputInvalid == true) animator.speed = 1.0f;

        if (motionCancel == true)
        {
            if (playerController.moveDirection.sqrMagnitude != 0.0f)
            {
                stateMachine.PS = P_Status.PLAYERSTATUS.MOVE;
                playerController.moveSpd = 7.0f;
            }
            else
            {
                stateMachine.PS = P_Status.PLAYERSTATUS.IDLE;
                playerController.moveSpd = 0.0f;
            }
        }
    }

    private void OnAttack(InputAction.CallbackContext obj)
    {
        if (inputInvalid == true) return;
        else
        {
            stateMachine.PS = P_Status.PLAYERSTATUS.ATTACK;
            animatorManager.Combo();
            inputInvalid = true;
            StartCoroutine("CoolTime");
        }
    }

    private void OnSpecialAttack(InputAction.CallbackContext obj)
    {
        if (inputInvalid == true) return;
        else
        {
            stateMachine.PS = P_Status.PLAYERSTATUS.ATTACK;
            animatorManager.Special();
            inputInvalid = true;
            StartCoroutine("CoolTime");
        }
    }

    IEnumerator CoolTime()
    {
        if (finishAttack == false) yield return new WaitForSeconds(timer);
        else yield return new WaitForSeconds(finishtimer);
        inputInvalid = false;
        finishAttack = false;
        motionCancel = true;
        StartCoroutine("CancelTime");
    }

    IEnumerator CancelTime()
    {
        yield return new WaitForSeconds(canceltimer);
        motionCancel = false;
    }

    public void FinishAttack_true()
    {
        finishAttack = true;
    }
}
