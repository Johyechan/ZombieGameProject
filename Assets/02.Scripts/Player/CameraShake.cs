using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    public float ShakeDuration = 1.75f;
    public float ShakeAmplitude;
    public float ShakeFrequency;

    private float ShakeElapsedTime = 0f;

    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    public PlayerAttack playerAttack;
    void Start()
    {
        virtualCameraNoise = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        if(!playerAttack.reloading)
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)))
            {
                ShakeAmplitude = 2f;
                ShakeFrequency = 2.5f;
                ShakeElapsedTime = ShakeDuration;
            }
        }
        
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            if (ShakeElapsedTime > 0)
            {
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

                ShakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }
    }

    public void HitShake()
    {
        ShakeAmplitude = 2.5f;
        ShakeFrequency = 5f;
        ShakeElapsedTime = ShakeDuration;
    }

}
