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


    private GameSession GetExistsSession()
    {
        var sessions = FindObjectsOfType<GameSession>();
        foreach (var gameSession in sessions)
        {
            if (gameSession != this)
                return gameSession;
        }

        return null;
    }
}
