using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReaderTMP : MonoBehaviour
{
    [SerializeField] private PlayerBrainTMP _player;

    public void Moviment(InputAction.CallbackContext context){
        Vector2 direction = context.ReadValue<Vector2>();
        _player.SetDirection(direction);
    }
}
