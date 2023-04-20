using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Compiler : MonoBehaviour
{
    Button Run_button;
    Text codeText;
    public GameObject Object;
    void Start()
    {
        codeText = gameObject.transform.GetChild(1).GetComponent<Text>();
        Run_button = gameObject.transform.GetChild(2).GetComponent<Button>();
        Run_button.onClick.AddListener(Run);
    }

    
    void Update()
    {
        
    }


    void Run()
    {
        Object.transform.position = new Vector3(-11.483f, -4.059f, 0);

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
            int Rep = 0;
            if (code_Array[i] == "move_right")
            {
                string StrRep = code_Array[i + 1];
                if(System.Char.IsDigit(StrRep[2]) == true)
                {
                    Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                    Rep = Rep * 10 + (int)System.Char.GetNumericValue(StrRep[2]);
                }
                else
                {
                    Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                }
                for (int j = 0; j < Rep; j++)
                {
                    HeroKnight.instance.Move_Right();
                //    Debug.Log(Object.transform.position.x);
                }  
                i += 1;
               //Debug.Log("right");
            }
            else if (code_Array[i] == "move_left")
            {
                string StrRep = code_Array[i + 1];
                if (System.Char.IsDigit(StrRep[2]) == true)
                {
                    Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                    Rep = Rep * 10 + (int)System.Char.GetNumericValue(StrRep[2]);
                }
                else
                {
                    Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                }
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Left();
                i += 1;
                //Debug.Log("left");   
            }
            else if (code_Array[i] == "move_up")
            {
                string StrRep = code_Array[i + 1];
                if (System.Char.IsDigit(StrRep[2]) == true)
                {
                    Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                    Rep = Rep * 10 + (int)System.Char.GetNumericValue(StrRep[2]);
                }
                else
                {
                    Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                }
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Up();
                i += 1;
                //Debug.Log("Up");   
            }
            else if (code_Array[i] == "move_down")
            {
                string StrRep = code_Array[i + 1];
                if (System.Char.IsDigit(StrRep[2]) == true)
                {
                    Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                    Rep = Rep * 10 + (int)System.Char.GetNumericValue(StrRep[2]);
                }
                else
                {
                    Rep = (int)System.Char.GetNumericValue(StrRep[1]);
                }
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Down();
                i += 1;
                //Debug.Log("Down");   
            }
        }

        
    }
}
