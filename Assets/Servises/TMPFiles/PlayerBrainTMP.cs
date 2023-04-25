using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBrainTMP : MonoBehaviour
{
    [SerializeField]private int speed;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void SetDirection(Vector2 direction){
        _direction = direction;
    }

    private void FixedUpdate() {
        var xV = _direction.x * speed;
        var yV = _direction.y * speed;


        _rigidbody.velocity = new Vector2(xV, yV);
        
    }
}
