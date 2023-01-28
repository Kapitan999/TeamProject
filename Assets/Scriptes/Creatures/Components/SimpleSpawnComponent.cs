using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawnComponent : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform point;
    [SerializeField] private int powerOfImpulse;

    public void SimpleSpawn() {
        var rigidbody = prefab.GetComponent<Rigidbody>();
        Instantiate(prefab, point.transform.position, Quaternion.identity);
        rigidbody.AddForce(Vector3.up * powerOfImpulse);
    }
}
