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
        ATTACK,　　　　　　
        DAMAGE,           
        INVINCIBLE,
    }

    [Header("現在の状態")]
    public PLAYERSTATUS PS = PLAYERSTATUS.IDLE;

    public enum PLAYERPLACE
    {
        GROUND,
        AIR,
    }

    [Header("現在の位置")]
    public PLAYERPLACE PP = PLAYERPLACE.GROUND;
}
