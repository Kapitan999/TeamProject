using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishing : MonoBehaviour
{
    private GameSession _session;

    public GameObject _finish;
    public GameObject _player;

    private void Start() {
        _session = FindObjectOfType<GameSession>();
        
    }
    

    [ContextMenu("Finish")]
    public void OnFinishLevel(){
        _player = GameObject.FindGameObjectWithTag("Player");
        _finish = GameObject.FindGameObjectWithTag("Finish");
        Vector3 tmp = new Vector3 (_finish.transform.position.x, _finish.transform.position.y - 0.5f, 0);
        if (_player.transform.position == tmp){
            // Debug.Log("111");

            _session.OnLevelComplite();
            SceneManager.LoadScene("LevelsWindow");
        }
    }

}
