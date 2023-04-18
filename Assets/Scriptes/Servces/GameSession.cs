using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int _levelIndex;
    

    public int LevelComplete => _levelIndex;
    private void Awake() {
        DontDestroyOnLoad(this);
    }

    public void OnLevelComplite(){
        _levelIndex++;
    }
}
