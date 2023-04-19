using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishing : MonoBehaviour
{
    private GameSession _session;

    private void Awake() {
        _session = FindObjectOfType<GameSession>();
    
    }

    public void OnFinishLevel(){
        _session.OnLevelComplite();
        SceneManager.LoadScene("LevelsWindow");
    }

}
