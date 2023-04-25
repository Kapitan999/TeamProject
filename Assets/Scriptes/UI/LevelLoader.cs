using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    private static LevelLoader Instance;
    
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }



    public void LoadLevel(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    
}
