using UnityEngine;
using UnityEngine.UI;

public class P_HpManager : MonoBehaviour
{
    public Slider HpSlider;
    public int Hp, MaxHp;

    void Start()
    {
        Hp = MaxHp;
        HpSlider.value = 1;
    }

    void FixedUpdate()
    {
        HpSlider.value = (float)Hp / MaxHp;
    }
}
