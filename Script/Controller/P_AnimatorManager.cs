using UnityEngine;

public class P_AnimatorManager : MonoBehaviour
{
    private P_Status stateMachine;
    private PlayerController playerController;
    private Animator animator;
    private PlayerAnimationKeyFreme animationkeyFreme;

    // �A�j���[�^�[�ɂ���֐���string�ő���@
    // string�ő�������֐��ł�if����bool�ɂ͎g���Ȃ�
    // �g���ɂ�animetorSet�Ŏg���K�v������

    string
        A_MoveSpd = "MoveSpd",
        A_Guard = "Guard",
        A_GuardHit = "GuardHit",
        A_Dodge = "Dodge",
        A_Combo = "Combo",
        A_Special = "Special",
        A_C_AwaySet = "C_AwaySet",
        A_C_AwayFinish = "C_AwayFinish",

        // �U�����̃J�E���^�[
        A_C_Attack = "C_Attack",

        // �U�����̃J�E���^�[
        A_C_Guard = "C_Guard",

        // �J�E���^�[�����t���O
        A_Success = "Success",

        // �n�ʐݒu�p�t���O
        A_isGround = "isGround",

        // �U�����󂯂����̃t���O
        A_Hit = "Hit",

        // �m�b�N�o�b�N����t���O
        A_KnockBack = "KnockBack",

        A_BlownAway = "BlownAway",

        A_Number = "Number",

        // ���[�V�����L�����Z��
        A_MotionCancel = "MotionCancel";

    [Header("����")]
    public bool GiveOut;

    void Start()
    {
        stateMachine = GetComponent<P_Status>();
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        animationkeyFreme = GetComponent<PlayerAnimationKeyFreme>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            animator.SetTrigger(A_GuardHit);
        }

        animator.SetFloat(A_MoveSpd, playerController.moveSpd, 0.2f, Time.deltaTime);
    }

    public void Guard_true()
    {
        animator.SetBool(A_Guard, true);
    }

    public void Guard_false()
    {
        animator.SetBool(A_Guard, false);

        // �K�[�h�̃R���C�_�[���\���@
        // �L�[�t���[���Ŗ߂��ꍇ�A�j���[�V���������܂Ȃ��Ƃ����Ȃ��̂Œx����������
        animationkeyFreme.K_Guard_false();
    }

    public void GuardHit()
    {
        animator.SetTrigger(A_GuardHit);
    }

    public void Dodge()
    {
        animator.SetTrigger(A_Dodge);
    }

    public void Combo()
    {
        animator.SetInteger(A_Number, 0);
        animator.SetTrigger(A_Combo);
    }

    public void Special()
    {
        animator.SetInteger(A_Number, 1);
        animator.SetTrigger(A_Combo);
    }

    public void C_Away()
    {
        if (GiveOut == false)
        {
            animator.SetTrigger(A_C_AwaySet);
            GiveOut = false;
        }
        else
        {
            animator.SetTrigger(A_C_AwayFinish);
            GiveOut = false;
        }
    }

    public void AttackCounter()
    {
        animator.SetTrigger(A_C_Attack);
    }

    public void GuardCounter()
    {
        animator.SetTrigger(A_C_Guard);
    }

    public void Success()
    {
        animator.SetBool(A_Success, true);
    }

    public void MotionCancel()
    {
        // Debug�ɏo�Ȃ����ǌ�������
        animator.SetTrigger(A_MotionCancel);
    }

    // �������
    public void BlownAway()
    {
        animator.SetTrigger(A_BlownAway);
    }

    //  -------------------- �C���^�[�t�F�[�X�̏��� --------------------
    // ���܂Ȃ��_���[�W
    public void Hit()
    {
        //Debug.Log("�G����U�����󂯂�");
        stateMachine.PS = P_Status.PLAYERSTATUS.MOVE;
        animator.SetTrigger(A_Hit);
    }

    // ����
    public void Knockback()
    {
        //Debug.Log("����");
        stateMachine.PS = P_Status.PLAYERSTATUS.DAMAGE;
        animator.SetTrigger(A_KnockBack);
    }
}
