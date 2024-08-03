using UnityEngine;
using UnityEngine.InputSystem;  // コントローラー対応するために必要

public class PlayerController : MonoBehaviour
{
    private P_Status stateMachine;
    private Animator animator;
    private P_AnimatorManager animatorManager;
    private P_HpManager p_HpManager;

    // InputSystem
    PlayerInput
        _Move,
        _Guard,
        _Dodge,
        _OpenMenu,
        _CloseMenu;

    float moveH, moveV;
    public Vector3 moveDirection;

    [Header("移動速度")]
    public float moveSpd = 4f;

    [Header("入力無効")]
    public bool inputInvalid;

    [Header("特殊回転")]
    public bool nomalRotation;
    public bool attackRotation;

    public bool moveStp;
    public bool moveCancel;

    [Header("モーションキャンセル")]
    public bool motionCancel;

    [Header("ダメージ")]
    public bool damage = false;

    float
        stateLength,
        animatorTime,
        peacenTage;

    void Awake()
    {
        // エディターにあるInputSystemの設定を取得
        TryGetComponent(out _Move);
        TryGetComponent(out _Guard);
        TryGetComponent(out _Dodge);
        TryGetComponent(out _OpenMenu);
        TryGetComponent(out _CloseMenu);

        stateMachine = GetComponent<P_Status>();
        animator = GetComponent<Animator>();
        animatorManager = GetComponent<P_AnimatorManager>();
        p_HpManager = GetComponent<P_HpManager>();
    }

    // 上でPlayerInputを宣言した後に、EneableとDisableで押されたボタンの、
    // アクションを自動で読みむ（InputActionに設定するのを省略出来る）
    void OnEnable()                  // InputSystem
    {
        _Move.actions["Move"].performed += OnMove;
        _Move.actions["Move"].canceled += OnMove;
        _Guard.actions["Guard"].performed += OnGuard;
        _Guard.actions["Guard"].canceled += OnGuard;
        _Dodge.actions["Dodge"].started += OnDodge;
        _OpenMenu.actions["OpenMenu"].started += OnOpenMenu;
        _CloseMenu.actions["CloseMenu"].started += OnCloseMenu;
    }

    void OnDisable()                 // InputSystem
    {
        _Move.actions["Move"].performed -= OnMove;
        _Move.actions["Move"].canceled -= OnMove;
        _Guard.actions["Guard"].performed -= OnGuard;
        _Guard.actions["Guard"].canceled -= OnGuard;
        _Dodge.actions["Dodge"].started -= OnDodge;
        _OpenMenu.actions["OpenMenu"].started -= OnOpenMenu;
        _CloseMenu.actions["CloseMenu"].started -= OnCloseMenu;
    }

    void FixedUpdate()
    {
        if (p_HpManager.Hp <= 0)
        {
            return;
        }

        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        moveDirection = new Vector3(moveH, 0f, moveV).normalized;

        float degree = Mathf.Atan2(moveH, moveV) * Mathf.Rad2Deg;
        //Debug.Log(degree);

        switch (stateMachine.PS)
        {
            case P_Status.PLAYERSTATUS.IDLE:
                moveSpd = 0f;
                if (moveDirection.magnitude > 0.1f)
                {
                    stateMachine.PS = P_Status.PLAYERSTATUS.MOVE;
                    moveSpd = 7f;
                }
                break;

            case P_Status.PLAYERSTATUS.MOVE:
                if (moveCancel == true) return;
                stateMachine.PS = P_Status.PLAYERSTATUS.MOVE;
                transform.position += horizontalRotation * moveDirection * moveSpd * Time.deltaTime;
                if (moveDirection.sqrMagnitude != 0.0f)
                    transform.rotation = Quaternion.Lerp(transform.rotation,
                        Quaternion.LookRotation(moveDirection) * horizontalRotation,
                        8.0f * Time.deltaTime);
                else stateMachine.PS = P_Status.PLAYERSTATUS.IDLE;
                break;

            case P_Status.PLAYERSTATUS.DAMAGE:
                moveSpd = 0f;
                inputInvalid = true;
                break;
        }



        if (nomalRotation == true || attackRotation == true)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            stateLength = stateInfo.length;
            animatorTime = stateInfo.normalizedTime % 1.0f;
            peacenTage = (animatorTime / stateLength) * 100f;
        }

        if (nomalRotation == true && peacenTage >= 0f)
        {
            if (moveDirection.sqrMagnitude != 0f)
                transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(moveDirection) * horizontalRotation,
                50f * Time.deltaTime);
            peacenTage = 0f;
            nomalRotation = false;
        }
        else if (attackRotation == true && peacenTage >= 0f)
        {
            if (moveDirection.sqrMagnitude != 0f)
                transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(moveDirection) * horizontalRotation,
                35f * Time.deltaTime);
            peacenTage = 0f;
            attackRotation = false;
        }
    }



    private void OnMove(InputAction.CallbackContext obj)
    {
        Vector2 MovVec = obj.action.ReadValue<Vector2>();
        moveH = MovVec.x;
        moveV = MovVec.y;

        // 反転に使えそう
        //float InputStick = MovVec.magnitude;
        //if (InputStick < 0.5f)
        //{
        //    Debug.Log(InputStick);
        //}
    }

    private void OnGuard(InputAction.CallbackContext obj)
    {
        if (p_HpManager.Hp <= 0) return;
        //if (InputInvalid == true) return;

        //if (obj.performed) 
        //{
        //    animatorController.Guard_true();
        //    MoveStp = true;
        //}
        //if (obj.canceled) 
        //{
        //    animatorController.Guard_false();
        //    MoveStp = false;
        //}
    }

    private void OnDodge(InputAction.CallbackContext obj)
    {
        if (p_HpManager.Hp <= 0) return;
        if (inputInvalid == true) return;
        else
        {
            inputInvalid = true;
            animatorManager.Dodge();
        }
    }

    private void OnOpenMenu(InputAction.CallbackContext obj)
    {
        //Time.timeScale = 0f;
        //_OpenMenu.SwitchCurrentActionMap("UI");
    }

    private void OnCloseMenu(InputAction.CallbackContext obj)
    {
        //Time.timeScale = 1f;
        //_CloseMenu.SwitchCurrentActionMap("Battle");
    }
}
