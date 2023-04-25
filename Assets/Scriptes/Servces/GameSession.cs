using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int _levelIndex;


    private Transform player;
    private Transform finish;

    private void Update()
    {
        //splayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();

       // if (player.position == finish.position)
      //  {
            
      //  }
    }

    public int LevelComplete => _levelIndex;
    private void Awake() {
        var exitSession = GetExistsSession();
        if (exitSession!=null){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(this);
        }
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
