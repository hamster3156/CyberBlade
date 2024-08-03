using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSearchManager : MonoBehaviour
{
    // �G�l�~�[�̃��X�g
    public List<GameObject> EnemyList = new List<GameObject>();

    // �P�ԋ߂��G�l�~�[
    public GameObject Enemy;

    // �G�l�~�[���T���͈͓��������t���O
    public bool isEnemy;

    // �G�l�~�[�Ƃ̋���
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
                    // EnemyList�ɓ����Ă�I�u�W�F�N�g�ƃv���C���[�̋������v�Z���āA�߂��I�u�W�F�N�g��nearEnemy
                    var p = transform.position;

                    // EnemyList�ɓ����Ă���G�����ԋ߂��G��Enemy�ɓ����
                    distance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distance <= 5)
                    {
                        Enemy = EnemyList.OrderBy(p => Vector3.Distance(p.transform.position, this.transform.position)).First();
                    }
                }

                // Enemy�������Ă�������s
                if (Enemy != null)
                {
                    // EnemyList�ɓ����Ă���G�Ƃ̋��������ꂽ��
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
            // Contains�œ����I�u�W�F�N�g�����X�g�ɓ����Ă���Ȃ�ʂ�Ȃ��悤�ɂȂ��Ă���
            EnemyList.Add(other.gameObject);
            isEnemy = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // Contains�œ����I�u�W�F�N�g�����X�g�ɓ����Ă���Ȃ�ʂ�Ȃ��悤�ɂȂ��Ă���
            EnemyList.Remove(other.gameObject);
        }
    }
}