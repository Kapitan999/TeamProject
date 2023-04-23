using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Compiler : MonoBehaviour
{
    Button Run_button;
    Text codeText;
    public GameObject Object;

    private Vector3 _firstPosition ;

    private void Awake() {
        _firstPosition = Object.transform.position;
        
    }
    private void Start()
    {
        codeText = gameObject.transform.GetChild(1).GetComponent<Text>();
        Run_button = gameObject.transform.GetChild(2).GetComponent<Button>();
        Run_button.onClick.AddListener(Run);
    }

    public void Run()
    {
        Object.transform.position = _firstPosition;

        //Not work
        string[] separators = new string[]
        {
            " ", "(", ")"
        };
        

        string Enters = "/n";
        //

        string code = codeText.text;

        // string[] code_Array = code.Split(separators, System.StringSplitOptions.None);

        
        // for (int i=0; i<code_Array.Length-1; i+=2){
            
        //     if (code_Array[i]=="move_right"){
        //         int step = System.Int32.Parse(code_Array[i+1]);
        //         for(int j = 0; j < step; j++)
        //             HeroKnight.instance.Move_Right();
        //         // i++;
        //     }
        // }


        string[] code_Array = code.Split(Enters, System.StringSplitOptions.None);

        
        for (int i=0; i<code_Array.Length; i++){
            Debug.Log(code_Array[i]);
            string[] words = code_Array[i].Split(separators ,System.StringSplitOptions.None);
            for (int j=0; j<words.Length; j++){
                Debug.Log(words[j]);
            }
            if (words[0]=="move_right"){
                int step = System.Int32.Parse(words[1]);
                for(int j = 0; j < step; j++)
                    HeroKnight.instance.Move_Right();
                // i++;
            }
        }

        // //Debug.Log(code_Array.Length);
        // for (int i=0; i <code_Array.Length-1; i++){
        //     string direction = code_Array[i];
        //     if(direction== "move_right"){
        //         string StrRep = code_Array[i + 1];
        //         int Rep = System.Int32.Parse(StrRep);
        //         for(int j = 0; j < Rep; j++)
        //             HeroKnight.instance.Move_Right();
        //         i += 1;
        //     }
        //     else if (direction == "move_left"){
        //         string StrRep = code_Array[i + 1];
        //         int Rep = System.Int32.Parse(StrRep);
        //         for (int j = 0; j < Rep; j++)
        //             HeroKnight.instance.Move_Left();
        //         i += 1;
        //     }
            
        //     else if(direction == "move_up"){
        //         string StrRep = code_Array[i + 1];
        //         int Rep =  System.Int32.Parse(StrRep);
        //         for (int j = 0; j < Rep; j++)
        //             HeroKnight.instance.Move_Up();
        //         i += 1;
        //     }
        //     else if (direction == "move_down"){
        //         string StrRep = code_Array[i + 1];
        //         int Rep = System.Int32.Parse(StrRep);
        //         for (int j = 0; j < Rep; j++)
        //             HeroKnight.instance.Move_Up();
        //         i += 1;
        //     }
                
        // }
    }


        // for(int i = 0; i < code_Array.Length - 1; i++)
        // {
        //     if (code_Array[i] == "move_right")
        //     {
        //         string StrRep = code_Array[i + 1];
        //         int Rep = (int)System.Char.GetNumericValue(StrRep[1]);
        //         for(int j = 0; j < Rep; j++)
        //             HeroKnight.instance.Move_Right();
        //         i += 1;
        //        //Debug.Log("right");
        //     }
        //     else if (code_Array[i] == "move_left")
        //     {
        //         string StrRep = code_Array[i + 1];
        //         int Rep = (int)System.Char.GetNumericValue(StrRep[1]);
        //         for (int j = 0; j < Rep; j++)
        //             HeroKnight.instance.Move_Left();
        //         i += 1;
        //         //Debug.Log("left");   
        //     }
        //     else if (code_Array[i] == "move_up")
        //     {
        //         string StrRep = code_Array[i + 1];
        //         int Rep = (int)System.Char.GetNumericValue(StrRep[1]);
        //         for (int j = 0; j < Rep; j++)
        //             HeroKnight.instance.Move_Up();
        //         i += 1;
        //         //Debug.Log("Up");   
        //     }
        //     else if (code_Array[i] == "move_down")
        //     {
        //         string StrRep = code_Array[i + 1];
        //         int Rep = (int)System.Char.GetNumericValue(StrRep[1]);
        //         for (int j = 0; j < Rep; j++)
        //             HeroKnight.instance.Move_Down();
        //         i += 1;
        //         //Debug.Log("Down");   
        //     }
        // }

        
    }
