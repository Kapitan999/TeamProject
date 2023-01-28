using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    private PlayerController player;

    private void Awake() {
        player = GetComponent<PlayerController>();
    }

    public void Movement(InputAction.CallbackContext context){
        var _direction = context.ReadValue<Vector3>();

        player.SetDirection(_direction);
    }
    
    public void Fix(InputAction.CallbackContext context){
        player.OnFix();
    }
}
