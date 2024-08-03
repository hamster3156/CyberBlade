using UnityEngine;

public class P_interface : MonoBehaviour, IHitable, IKnockBackable
{
    private P_AnimatorManager animatorManager;
    private P_HpManager p_HpManager;

    void Start()
    {
        animatorManager = GetComponent<P_AnimatorManager>();
        p_HpManager = GetComponent<P_HpManager>();
    }

    public void TakeHit()
    {
        animatorManager.Hit();
    }

    public void TakeKnockback()
    {
        p_HpManager.Hp -= 2;
        animatorManager.Knockback();
    }
}
