using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_EffectManager : MonoBehaviour
{
    public GameObject[] EfctPos;
    public GameObject[] Efcts;

    public void E_Comb_6()
    {
        Instantiate(Efcts[0], EfctPos[0].transform.position, EfctPos[0].transform.rotation);
    }

    public void E_Special_3_2()
    {
        Instantiate(Efcts[1], EfctPos[0].transform.position, EfctPos[0].transform.rotation);
    }

    public void E_Special_5_2()
    {
        Instantiate(Efcts[2], EfctPos[1].transform.position,EfctPos[1].transform.rotation);
    }
}
