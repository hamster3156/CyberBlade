using UnityEngine;

public class P_AnimatorManager : MonoBehaviour
{
    private P_Status stateMachine;
    private PlayerController playerController;
    private Animator animator;
    private PlayerAnimationKeyFreme animationkeyFreme;

    // アニメーターにある関数をstringで代入　
    // stringで代入した関数ではif文やboolには使えない
    // 使うにはanimetorSetで使う必要がある

    string
        A_MoveSpd = "MoveSpd",
        A_Guard = "Guard",
        A_GuardHit = "GuardHit",
        A_Dodge = "Dodge",
        A_Combo = "Combo",
        A_Special = "Special",
        A_C_AwaySet = "C_AwaySet",
        A_C_AwayFinish = "C_AwayFinish",

        // 攻撃時のカウンター
        A_C_Attack = "C_Attack",

        // 攻撃時のカウンター
        A_C_Guard = "C_Guard",

        // カウンター成功フラグ
        A_Success = "Success",

        // 地面設置用フラグ
        A_isGround = "isGround",

        // 攻撃を受けた時のフラグ
        A_Hit = "Hit",

        // ノックバックするフラグ
        A_KnockBack = "KnockBack",

        A_BlownAway = "BlownAway",

        A_Number = "Number",

        // モーションキャンセル
        A_MotionCancel = "MotionCancel";

    [Header("抜刀")]
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

        // ガードのコライダーを非表示　
        // キーフレームで戻す場合アニメーションを挟まないといけないので遅延がかかる
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
        // Debugに出ないけど原因ここ
        animator.SetTrigger(A_MotionCancel);
    }

    // 吹っ飛び
    public void BlownAway()
    {
        animator.SetTrigger(A_BlownAway);
    }

    //  -------------------- インターフェースの処理 --------------------
    // 怯まないダメージ
    public void Hit()
    {
        //Debug.Log("敵から攻撃を受けた");
        stateMachine.PS = P_Status.PLAYERSTATUS.MOVE;
        animator.SetTrigger(A_Hit);
    }

    // 怯む
    public void Knockback()
    {
        //Debug.Log("怯んだ");
        stateMachine.PS = P_Status.PLAYERSTATUS.DAMAGE;
        animator.SetTrigger(A_KnockBack);
    }
}
