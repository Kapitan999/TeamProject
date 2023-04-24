using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerTMP : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private EnterEvent _action;
    
    private void OnCollisionStay(Collision collision)
    {
        if (!string.IsNullOrEmpty(_tag) && collision.gameObject.CompareTag(_tag)) return;
        {
            _action?.Invoke(collision.gameObject);
            Debug.Log("YEs");
        }
        Debug.Log("NI");
    }
}
