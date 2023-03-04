using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EnterTriggerComponent : MonoBehaviour
{
    [SerializeField] private string tag;
    [SerializeField] private EnterEvent action;
    [SerializeField] private bool isRandom = false;
    [SerializeField] private int percentage =0;

    private void OnTriggerEnter(Collider other) {

        if (!string.IsNullOrEmpty(tag) && !other.gameObject.CompareTag(tag)) return;
        if (!isRandom){action?.Invoke(other.gameObject); }

        else {
            var random = UnityEngine.Random.Range(1, 100);
            if (random<= percentage){
                action?.Invoke(other.gameObject);
            }
        }
    }


}
[Serializable]
public class EnterEvent : UnityEvent<GameObject> 
{
}
