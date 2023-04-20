using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputReader : MonoBehaviour
{
    [SerializeField] private CameraBrain _camera;



    public void Menu(InputAction.CallbackContext context){
        if (context.canceled){
            _camera.ShowMenu();

        }
    }

    public void ShowTarget(InputAction.CallbackContext context){
        if (context.canceled){
            _camera.OnShowTarger();
            
        }
    }
}
