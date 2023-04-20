using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerTMP : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private EnterEvent _action;
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!string.IsNullOrEmpty(_tag) && !other.gameObject.CompareTag(_tag)) return;

        _action?.Invoke(other.gameObject);
    }
}
