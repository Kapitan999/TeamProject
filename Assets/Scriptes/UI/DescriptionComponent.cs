using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionComponent : MonoBehaviour
{
    public LevelWindow _levelWindow;
    [SerializeField]private GameObject descriptional;
    private void Start() {
        _levelWindow = FindObjectOfType<LevelWindow>();
    }
    
    public void OnStart(){
        _levelWindow.OnLoadLevel();
        descriptional.SetActive(false);

    }

    public void OnOff(){
        _levelWindow.Desselect();
        descriptional.SetActive(false);
    }

}
