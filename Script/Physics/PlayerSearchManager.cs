using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSearchManager : MonoBehaviour
{
    // エネミーのリスト
    public List<GameObject> EnemyList = new List<GameObject>();

    // １番近いエネミー
    public GameObject Enemy;

    // エネミーが探索範囲内入ったフラグ
    public bool isEnemy;

    // エネミーとの距離
    public float distance;

    public bool MoveStop;


    void Start()
    {
        Enemy = null;
    }

    void FixedUpdate()
    {
        if (isEnemy == true)
        {
            foreach (var enemy in EnemyList)
            {
                if (enemy != null)
                {
                    // EnemyListに入ってるオブジェクトとプレイヤーの距離を計算して、近いオブジェクトをnearEnemy
                    var p = transform.position;

                    // EnemyListに入っている敵から一番近い敵をEnemyに入れる
                    distance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distance <= 5)
                    {
                        Enemy = EnemyList.OrderBy(p => Vector3.Distance(p.transform.position, this.transform.position)).First();
                    }
                }

                // Enemyが入っていたら実行
                if (Enemy != null)
                {
                    // EnemyListに入っている敵との距離が離れた時
                    float dis = Vector3.Distance(transform.position, Enemy.transform.position);
                    if (dis >= 5)
                    {
                        Enemy = EnemyList.OrderByDescending(p => Vector3.Distance(p.transform.position, this.transform.position)).First();
                        Enemy = null;
                    }

                    if (dis <= 1.5)
                    {
                        MoveStop = true;
                    }
                    else
                    {
                        MoveStop = false;
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !EnemyList.Contains(other.gameObject))
        {
            // Containsで同じオブジェクトがリストに入っているなら通らないようになっている
            EnemyList.Add(other.gameObject);
            isEnemy = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // Containsで同じオブジェクトがリストに入っているなら通らないようになっている
            EnemyList.Remove(other.gameObject);
        }
    }
}