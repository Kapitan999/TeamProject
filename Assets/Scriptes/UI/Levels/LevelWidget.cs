using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWidget : MonoBehaviour
{
    [SerializeField] private string numberLevel;
    [SerializeField]private Text number;
    [SerializeField] private GameObject locked;
    [SerializeField] private GameObject finished;
    [SerializeField]private GameObject selection;
    [SerializeField] private Button button;
    [SerializeField] private string sceneName;

    public bool _isFinished = false;
    public bool _isLocked = true;
    public bool _isSelected = false;
    private GameSession  session;
    private LevelWindow _levelWindow;

    private void Awake() {
        session = FindObjectOfType<GameSession>();
        button.interactable = false;
        _levelWindow = FindObjectOfType<LevelWindow>();
        UpdateView();
    }
    public void OnOpen(){
        _isLocked = false;
        button.interactable = true;
        UpdateView();
    }
    public void OnFinished(){
        _isFinished = true;
        UpdateView();
    }

    public void OnSelect(){
        var selected = FindObjectsOfType<LevelWidget>();
        
        for (int i=0; i<selected.Length; i++){
            selected[i]._isSelected = false;
            selected[i].UpdateView();
        }

        _isSelected = true;
        _levelWindow.SelectionLevel();

        UpdateView();
    }

    public void OnStartLevel(){
        SceneManager.LoadScene(sceneName);
    }
    public void OnDesselect(){
        _isSelected = false;
        UpdateView();
    }

    public void UpdateView(){
        
        number.text= numberLevel;
        locked.SetActive(_isLocked);
        finished.SetActive(_isFinished);
        selection.SetActive(_isSelected);
    }
}
