using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera m_vcam = null;
    [System.NonSerialized] private CinemachineBasicMultiChannelPerlin m_noiseComp = null;

    public enum ShakStatus
    {
        None,
        Small,
        Medium,
        Large,
    }

    [Header("åªç›ÇÃóhÇÍ")]
    public ShakStatus SS = ShakStatus.None;

    [Header("óhÇÍ(è¨)")]
    public float S_Amplitude, S_Frequency;

    [Header("óhÇÍ(íÜ)")]
    public float M_Amplitude, M_Frequency;

    [Header("óhÇÍ(ëÂ)")]
    public float L_Amplitude, L_Frequency;

    void Start()
    {
        m_vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        m_noiseComp = m_vcam.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();

        //if(m_noiseComp == null)
        //{
        //    Debug.LogError("No MultiChannelPerlin on the virtual camera.", this);
        //}
        //else
        //{
        //    Debug.Log($"Noise Component: {m_noiseComp}");
        //}
    }

    void FixedUpdate()
    {
        switch (SS)
        {
            case ShakStatus.None:
                m_noiseComp.m_AmplitudeGain = 0f;
                m_noiseComp.m_FrequencyGain = 0f;
                break;

            case ShakStatus.Small:
                m_noiseComp.m_AmplitudeGain = S_Amplitude;
                m_noiseComp.m_FrequencyGain = S_Amplitude;
                break;

            case ShakStatus.Medium:
                m_noiseComp.m_AmplitudeGain = M_Amplitude;
                m_noiseComp.m_FrequencyGain = M_Frequency;
                break;

            case ShakStatus.Large:
                m_noiseComp.m_AmplitudeGain = L_Amplitude;
                m_noiseComp.m_FrequencyGain = L_Frequency;
                break;
        }
    }
}