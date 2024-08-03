using UnityEngine;

public class PlayerAnimationKeyFreme : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;
    private P_AnimatorManager animatorManager;
    private AudioSource audioSource;
    private SoundManager soundManager;
    private TimeScaleManager timeScaleManager;
    private ShakeCameraManager shakeCameraManager;
    private P_EffectManager effectManger;

    [Header("刀")]
    public Collider[] KC;

    [Header("コンボエフェクト")]
    [SerializeField] ParticleSystem[] CEs;

    [Header("コンボサウンド")]
    [SerializeField] AudioClip AttackSound;

    [Header("コライダー")]
    [SerializeField] Collider[] Cs;

    [Header("スペシャルエフェクト")]
    [SerializeField] ParticleSystem[] SEs;

    [Header("ガードコライダー")]
    [SerializeField] GameObject[] Guards;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        animatorManager = GetComponent<P_AnimatorManager>();
        audioSource = GetComponent<AudioSource>();
        soundManager = GetComponent<SoundManager>();
        timeScaleManager = GameObject.Find("GameManager").GetComponent<TimeScaleManager>();
        shakeCameraManager = GameObject.Find("CameraManager").GetComponent<ShakeCameraManager>();
        effectManger = GameObject.Find("EffectManager").GetComponent<P_EffectManager>();
    }

    // --- アニメーター再生速度 ---

    public void A_Spd_half_1()
    {
        animator.speed = 0.5f;
    }

    public void A_Spd_half_2()
    {
        animator.speed = 0.7f;
    }

    // --- 回転可能 ---
    public void NomalRotation()
    {
        playerController.nomalRotation = true;
    }

    // --- 刀 ---
    public void KC_on()
    {
        KC[0].enabled = true;
    }

    public void KC_of()
    {
        KC[0].enabled = false;
    }
    public void KCS_on()
    {
        KC[1].enabled = true;
    }

    public void KCS_of()
    {
        KC[1].enabled = false;
    }

    // --- コライダー ---

    public void Combo_5_2col_on()
    {
        Cs[0].enabled = true;
    }

    public void Combo_5_2col_off()
    {
        Cs[0].enabled = false;
    }

    public void SE_2_2col_on()
    {
        Cs[1].enabled = true;
    }

    public void SE_2_2col_off()
    {
        Cs[1].enabled = false;
    }

    public void SE_4_2col_on()
    {
        Cs[2].enabled = true;
    }

    public void SE_4_2col_off()
    {
        Cs[2].enabled = false;
    }

    public void SE_5_1col_on()
    {
        Cs[3].enabled = true;
    }

    public void SE_5_1col_off()
    {
        Cs[3].enabled = false;
    }

    public void SE_5_2col_on()
    {
        Cs[4].enabled = true;
        Cs[5].enabled = true;
        Cs[6].enabled = true;
    }

    public void SE_5_2col_off()
    {
        Cs[4].enabled = false;
        Cs[5].enabled = false;
        Cs[6].enabled = false;
    }

    // --- モーション移動 ---
    public void MotionMove()
    {
        A_Attack.MotionMove = false;
        A_Dodge.DodgeMove = false;
        A_Damage.DamageBack = false;
    }

    public void MotionUp_true()
    {
        A_Attack.MotionUp = true;
    }

    public void MotionUp_false()
    {
        A_Attack.MotionUp = false;
    }

    public void FastForward_true()
    {
        A_Attack.FastForward = true;
    }

    public void FastForward_false()
    {
        A_Attack.FastForward = false;
    }

    // --- コンボエフェクト ---

    public void CE_1()
    {
        CEs[0].Play();
    }

    public void CE_2()
    {
        CEs[1].Play();
    }

    public void CE_3()
    {
        CEs[2].Play();
    }

    public void CE_4()
    {
        CEs[3].Play();
    }

    public void CE_5()
    {
        CEs[4].Play();
    }

    public void CE_6_1()
    {
        CEs[5].Play();
    }

    public void CE_6_2()
    {
        CEs[6].Play();
    }

    public void CE_6_3()
    {
        effectManger.E_Comb_6();
    }

    // --- スペシャルエフェクト ---

    public void SE_0()
    {
        SEs[0].Play();
    }

    public void SE_1()
    {
        SEs[1].Play();
    }

    public void SE_2_1()
    {
        SEs[2].Play();
    }

    public void SE_2_2()
    {
        SEs[3].Play();
        //SEs[4].Play();
    }

    public void SE_3_1()
    {
        SEs[5].Play();
    }

    public void SE_3_2()
    {
        SEs[6].Play();
    }

    public void SE_4_1()
    {
        SEs[7].Play();
    }

    public void SE_4_2()
    {
        SEs[8].Play();
    }

    public void SE_5_1()
    {
        SEs[9].Play();
    }

    public void SE_5_2()
    {
        SEs[10].Play();
    }

    public void SE_5_3()
    {
        effectManger.E_Special_5_2();
    }

    // --- サイクロン (剣ビーム見たいなもの) ---
    public void CycloneShot()
    {
        //effectManger.CycCount++;
        //effectManger.CycObj[effectManger.CycCount].transform.parent = null;
        //Cs.Play();
    }

    // --- 強調スロー ---
    public void EmphasisStart()
    {
        timeScaleManager.Emphasis();
    }

    public void EmphasisStart_2()
    {
        timeScaleManager.Emphasis_2();
    }

    public void EmphasisStart_3()
    {
        timeScaleManager.Emphasis_3();
    }

    // --- カメラ揺れ
    public void ShakStatus_None()
    {
        shakeCameraManager.SS = ShakeCameraManager.ShakStatus.None;
    }

    public void ShakStatus_Small()
    {
        shakeCameraManager.SS = ShakeCameraManager.ShakStatus.Small;
    }

    public void ShakStatus_Medium()
    {
        shakeCameraManager.SS = ShakeCameraManager.ShakStatus.Medium;
    }

    public void ShakStatus_Large()
    {
        shakeCameraManager.SS = ShakeCameraManager.ShakStatus.Large;
    }

    // --- コンボサウンド
    public void AttackSoundPlay()
    {
        //audioSource.PlayOneShot(AttackSound);

        // エラー出るからいったん米
        //soundManager.PlayAttackSE();
    }

    // --- ガード,回避
    // Guard
    public void K_Guard_true()
    {
        Guards[0].SetActive(true);
        PlayerBladePhysicsManager.Hit = true;
    }

    public void K_Guard_false()
    {
        Guards[0].SetActive(false);
        PlayerBladePhysicsManager.Hit = false;
    }
}
