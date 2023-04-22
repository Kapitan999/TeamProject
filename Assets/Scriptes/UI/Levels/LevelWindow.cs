using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelWindow : MonoBehaviour
{
    [SerializeField] private GameObject description;
    [SerializeField] private GameObject final;


    private int levelComplete;
    public LevelWidget[] levels;
    private GameSession  session;
    public Canvas canvas;
    private void Awake() {
        canvas = FindObjectOfType<Canvas>();
        session = FindObjectOfType<GameSession>();
        levelComplete = session.LevelComplete;
        
        // System.Array.Reverse(levels);
    }
    private void Start() {
        if (levelComplete<= levels.Length){
            for (int i =0; i<session.LevelComplete; i++){
                levels[i].OnOpen();
            }
        }
        else{ 
            final.SetActive(true);
        }
    }
        

    public void Desselect(){
        for (int i=0; i< levels.Length; i++){
            levels[i].OnDesselect();
        }
    }

    [ContextMenu("Show Description")]
    public void SelectionLevel(){
        description.SetActive(true);
    }

    public void OnLoadLevel(){
        foreach(var level in levels){
            if (level._isSelected == true){
                level.OnStartLevel();
            }
        }
    }
}
