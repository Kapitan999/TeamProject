using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [Space]
    [Header("Params")]
    [SerializeField] private int speed = 10;


    [Space]
    [Header("Interactions")]
    [SerializeField] private DamageComponent damage; 

    
    private Rigidbody rigidbody;
    private Vector3 direction;
    private Transform transform;


    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }
    public void SetDirection(Vector3 _direction){
        direction = _direction;
    }
    private void SetRotation(){
        
    }
    private void FixedUpdate() {
        rigidbody.velocity = new Vector3(direction.x* speed, 0, direction.z* speed);
        if (rigidbody.velocity != Vector3.zero){
            SetRotation();
        }
    }   
    
    public void OnFix(){

    }
}
