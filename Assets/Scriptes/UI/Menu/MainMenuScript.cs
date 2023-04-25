using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenuScript : MonoBehaviour
{
    // [SerializeField] private GameObject _options;
    [SerializeField] private string _nameScene;


    // public void ShowSettings(){
    //     var window = Resources.Load<GameObject>("");
    // }
    public void StartGame(){
        var loader = FindObjectOfType<LevelLoader>();
        loader.LoadLevel(_nameScene);
    }
    public void Exit(){
        Application.Quit();
    }
}
