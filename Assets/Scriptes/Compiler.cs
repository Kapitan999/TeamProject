using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Compiler : MonoBehaviour
{
    Button Run_button;
    Text codeText;
    [SerializeField] private GameObject Object;

    private HeroKnight _player;
    private Vector3 firstTransform;

    private void Awake() {
        firstTransform = Object.transform.position;
    }
    
    private void Start()
    {
        _player = Object.GetComponent<HeroKnight>();
        codeText = gameObject.transform.GetChild(1).GetComponent<Text>();
        Run_button = gameObject.transform.GetChild(2).GetComponent<Button>();
        Run_button.onClick.AddListener(Run);
    }



    public void Run()
    {
        Object.transform.position = firstTransform;

        //Not work
        char[] separators = new char[]
        {
            ' ', ';'
        };
        //

        string code = codeText.text;

        string[] code_Array = code.Split();

        //Debug.Log(code_Array.Length);


        for(int i = 0; i < code_Array.Length - 1; i++)
        {
            if (code_Array[i] == "move_right")
            {
                string StrRep = code_Array[i + 1];
                int Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                for(int j = 0; j < Rep; j++)
                    _player.Move_Right();
                i += 1;
               //Debug.Log("right");
            }
            else if (code_Array[i] == "move_left")
            {
                string StrRep = code_Array[i + 1];
                int Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                for (int j = 0; j < Rep; j++)
                    _player.Move_Left();
                i += 1;
                //Debug.Log("left");   
            }
            else if (code_Array[i] == "move_up")
            {
                string StrRep = code_Array[i + 1];
                int Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                for (int j = 0; j < Rep; j++)
                    _player.Move_Up();
                i += 1;
                //Debug.Log("Up");   
            }
            else if (code_Array[i] == "move_down")
            {
                string StrRep = code_Array[i + 1];
                int Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                for (int j = 0; j < Rep; j++)
                    _player.Move_Down();
                i += 1;
                //Debug.Log("Down");   
            }
        }

        
    }
}
