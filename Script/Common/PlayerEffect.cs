using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public float EfctTime = 5f;
    void FixedUpdate()
    {
        EfctTime -= Time.deltaTime;
        if (EfctTime <= 0) Destroy(gameObject);
    }
}
