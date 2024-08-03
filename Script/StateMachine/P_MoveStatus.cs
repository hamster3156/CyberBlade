using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_MoveStatus :MonoBehaviour
{
    private Rigidbody rigidbody;
    public enum MOVESTATUS
    {
        NONE,
        MOVE,
        FASTMOVE,
        MOVEUP,
    }

    [Header("åªç›ÇÃà⁄ìÆèÛë‘")]
    public MOVESTATUS MS = MOVESTATUS.NONE;

    public float 
        moveSpd, 
        fastmoveSpd, 
        moveupSpd;

     void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        switch (MS)
        {
            case MOVESTATUS.MOVE:
                rigidbody.velocity = transform.forward * moveSpd;
                break;

            case MOVESTATUS.FASTMOVE:
                rigidbody.velocity = transform.forward * fastmoveSpd;
                break;

            case MOVESTATUS.MOVEUP:
                rigidbody.velocity = transform.up * moveupSpd;
                break;
        }
    }

    public void MS_None()
    {
        MS = MOVESTATUS.NONE;
    }

    public void  MS_Move()
    {
        MS = MOVESTATUS.MOVE;
    }

    public void MS_FastMove()
    {
        MS = MOVESTATUS.FASTMOVE;
    }

    public void MS_MoveUp()
    {
        MS = MOVESTATUS.MOVEUP;
    }
}
