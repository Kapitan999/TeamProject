using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeTime=0.3f;
    [SerializeField] private float intensity = 3f;

    private CinemachineBasicMultiChannelPerlin cinemachine;
    private Coroutine coroutine;

    private void Awake() {
        var virtCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachine = virtCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(){
        if(coroutine!=null){
            StopShake();
        }
        coroutine = StartCoroutine(StartShake());
    }
    private IEnumerator StartShake(){
        cinemachine.m_FrequencyGain = intensity;
        yield return new WaitForSeconds(shakeTime);
        StopShake();
    }


    private void StopShake(){
        cinemachine.m_FrequencyGain = 0;
        StopCoroutine(coroutine);
        coroutine = null;
    }

}
