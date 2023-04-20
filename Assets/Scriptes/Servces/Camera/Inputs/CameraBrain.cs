using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    [SerializeField]private GameObject _menu;
    


    public void ShowMenu(){
        var canvas = GameObject.FindWithTag("GameCanvas").GetComponent<Canvas>();
        if (canvas!=null){
            Instantiate(_menu, canvas.transform);
        }
    }

    public void OnShowTarger(){
        var showing = FindObjectOfType<ShowTarget>();
        if (showing!=null){
            showing.Play();
        }
    }
}
