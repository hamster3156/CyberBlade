using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectDetection : MonoBehaviour
{
    public float MaxDistance;
    public GameObject RayPos;

    void Start()
    {

    }

    void FixedUpdate()
    {
        RayCast();
    }

    public void RayCast()
    {
        Debug.DrawRay(RayPos.transform.position, transform.forward * MaxDistance, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(RayPos.transform.position, transform.forward, out hit, MaxDistance))
        {
            if (hit.collider.tag == "Wall")
            {
                A_Attack.MoveStp = true;
            }
        }
        else A_Attack.MoveStp = false;
    }
}
