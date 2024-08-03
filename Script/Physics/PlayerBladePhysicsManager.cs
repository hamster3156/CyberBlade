using UnityEngine;

public class PlayerBladePhysicsManager : MonoBehaviour
{
    private P_Status stateMachine;
    private P_AnimatorManager animatorManager;
    private TimeScaleManager timeScaleManager;
    public static bool Hit;

    void Start()
    {
        stateMachine = GetComponentInParent<P_Status>();
        animatorManager = GetComponentInParent<P_AnimatorManager>();
        timeScaleManager = GameObject.Find("GameManager").GetComponent<TimeScaleManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "E_Attack" && Hit == true)
        {
            animatorManager.GuardHit();
        }

        switch (stateMachine.PS)
        {
            case P_Status.PLAYERSTATUS.ATTACK:
                IKnockBackable knockBackable = other.GetComponent<IKnockBackable>();
                if (knockBackable != null)
                {
                    knockBackable.TakeKnockback();
                    timeScaleManager.TimeScale();
                }
                break;
        }
    }
}
