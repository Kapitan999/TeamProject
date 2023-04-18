using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // [SerializeField] private GameObject _options;

    // public void ShowSettings(){
    //     var window = Resources.Load<GameObject>("");
    // }
    private LevelLoader loader;
    private void Awake() {
        loader = FindObjectOfType<LevelLoader>();
    }
    public void Resume(){
        Time.timeScale =1;
    }
    public void ChangeLevel(){
        loader.LoadLevel("LevelsWindow");
    }
    public void Exit(){
        loader.LoadLevel("MainMenu");
    }

}
