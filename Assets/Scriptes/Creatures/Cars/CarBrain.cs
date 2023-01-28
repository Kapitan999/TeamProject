using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBrain : MonoBehaviour
{
    // [SerializeField] private int minSpeed;
    // [SerializeField] private int maxSpeed;

    [SerializeField] public int speed;
    [SerializeField] private int countDamage;
    public bool invert = false;
    private RandomSpawnComponent spawn;
    private Rigidbody rigidbody;
    // private int speed;
    private int multiply =1;
    private void Awake() {
        // speed = Random.Range(minSpeed, maxSpeed);
        spawn = FindObjectOfType<RandomSpawnComponent>();
        rigidbody = GetComponent<Rigidbody>();
        if(invert){
            multiply = -1;
        }

    }

    private void FixedUpdate() {
        rigidbody.velocity = new Vector3(transform.position.x * speed * multiply , 0, 0);
    }

    private void OnDestroy() {
        spawn.Spawn();
    }

}
