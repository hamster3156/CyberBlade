using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    private P_Status stateMachine;

    public enum TimeStatus
    {
        None,
        Short,
        Nomal,
        Long,
    }

    [Header("���Ԃ̒���")]
    public TimeStatus TS = TimeStatus.None;

    void Start()
    {
        stateMachine = GameObject.Find("Player").GetComponent<P_Status>();
    }

    public void TargetRost()
    {
        Debug.Log("�^�[�Q�b�g���|�ꂽ");
    }

    // �q�b�g�X�g�b�v�iUnity�S�̂̍Đ����Ԃ�ς���j
    public void TimeScale()
    {
        switch (stateMachine.PS)
        {
            case P_Status.PLAYERSTATUS.ATTACK:
                TS = TimeStatus.Short;
                Time.timeScale = 0.8f;
                StartCoroutine("TimeScaleReset");
                break;
        }
    }

    public void Emphasis()
    {
        TS = TimeStatus.Short;
        Time.timeScale = 0.15f;
        StartCoroutine("TimeScaleReset");
    }

    public void Emphasis_2()
    {
        TS = TimeStatus.Short;
        Time.timeScale = 0.1f;
        StartCoroutine("TimeScaleReset");
    }

    public void Emphasis_3()
    {
        TS = TimeStatus.Short;
        Time.timeScale = 0.05f;
        StartCoroutine("TimeScaleReset");
    }

    IEnumerator TimeScaleReset()
    {
        switch (TS)
        {
            case TimeStatus.Short:
                yield return new WaitForSecondsRealtime(0.2f);
                break;

            case TimeStatus.Nomal:
                yield return new WaitForSecondsRealtime(0.4f);
                break;

            case TimeStatus.Long:
                yield return new WaitForSecondsRealtime(0.6f);
                break;
        }

        TS = TimeStatus.None;
        Time.timeScale = 1.0f;
    }
}
