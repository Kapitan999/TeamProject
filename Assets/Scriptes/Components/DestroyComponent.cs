using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    [SerializeField] private GameObject target;

    public void Destroy(){
        Destroy(target);
    }
}
