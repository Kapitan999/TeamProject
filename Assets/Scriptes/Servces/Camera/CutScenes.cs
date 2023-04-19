using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutScenes : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CinemachineVirtualCamera _camera;


    private static readonly int Show = Animator.StringToHash("show");

    public void SetPosition(Vector3 targetPosition){
        targetPosition.z = _camera.transform.position.z;
        _camera.transform.position = targetPosition;
    }

    public void SetState(bool isShown)
    {
        _animator.SetBool(Show, isShown);
    }
}
