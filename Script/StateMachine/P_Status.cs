using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Status : MonoBehaviour
{
    public enum PLAYERSTATUS
    {
        IDLE,       
        MOVE,        
        DODGE,       
        ATTACK,�@�@�@�@�@�@
        DAMAGE,           
        INVINCIBLE,
    }

    [Header("���݂̏��")]
    public PLAYERSTATUS PS = PLAYERSTATUS.IDLE;

    public enum PLAYERPLACE
    {
        GROUND,
        AIR,
    }

    [Header("���݂̈ʒu")]
    public PLAYERPLACE PP = PLAYERPLACE.GROUND;
}
