using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Compiler : MonoBehaviour
{
    Button Run_button;
    Text codeText;
    Text ErrorText;
    [SerializeField] private GameObject Object;
    private Vector3 firstTransform;
    int errorIndex = -1;
    private void Awake() {
        firstTransform = Object.transform.position;
    }
    
    private void Start()
    {
        codeText = gameObject.transform.GetChild(1).GetComponent<Text>();
        ErrorText = gameObject.transform.GetChild(3).GetComponent<Text>();
        Run_button = gameObject.transform.GetChild(2).GetComponent<Button>();
        Run_button.onClick.AddListener(Run);
    }



    private static int StrToInt(string value)
       {
       int result = 0;
       for (int i = 0; i < value.Length; i++)
       {
           char letter = value[i];
           result = 10 * result + (letter - 48);
       }
      return result;
      }



    private void Control(string[] code_Array)
    {
        for (int i = 0; i < code_Array.Length - 1; i++)
        {
            if (code_Array[i] == "move_right")
            {
                string StrRep = code_Array[i + 1];
                string StrNumber = "";
                for (int j = 0; j < StrRep.Length; j++)
                {
                    if ((StrRep[j] != '(') && (StrRep[j] != ')'))
                        StrNumber += StrRep[j];
                }
                int Rep = StrToInt(StrNumber);
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Right();
                i += 1;
                //Debug.Log("right");
            }
            else if (code_Array[i] == "move_left")
            {
                string StrRep = code_Array[i + 1];
                string StrNumber = "";
                for (int j = 0; j < StrRep.Length; j++)
                {
                    if ((StrRep[j] != '(') && (StrRep[j] != ')'))
                        StrNumber += StrRep[j];
                }
                int Rep = StrToInt(StrNumber);
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Left();
                i += 1;
                //Debug.Log("left");   
            }
            else if (code_Array[i] == "move_up")
            {
                string StrRep = code_Array[i + 1];
                string StrNumber = "";
                for (int j = 0; j < StrRep.Length; j++)
                {
                    if ((StrRep[j] != '(') && (StrRep[j] != ')'))
                        StrNumber += StrRep[j];
                }
                int Rep = StrToInt(StrNumber);
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Up();
                i += 1;
                //Debug.Log("Up");   
            }
            else if (code_Array[i] == "move_down")
            {
                string StrRep = code_Array[i + 1];
                string StrNumber = "";
                for (int j = 0; j < StrRep.Length; j++)
                {
                    if ((StrRep[j] != '(') && (StrRep[j] != ')'))
                        StrNumber += StrRep[j];
                }
                int Rep = StrToInt(StrNumber); 
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Down();
                i += 1;
                //Debug.Log("Down");   
            }
            else
            {
                errorIndex = i;
                i += 1;
                Debug.Log(errorIndex);
                break;
            }
        }
    }



    private void Run()
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

         


         if(code_Array.Length > 1)
         {
            Control(code_Array);
         }
         else
         {
            if (code_Array[0] == "move_right")
            {
                string StrRep = code_Array[1];
                string StrNumber = "";
                for (int j = 0; j < StrRep.Length; j++)
                {
                    if ((StrRep[j] != '(') && (StrRep[j] != ')'))
                        StrNumber += StrRep[j];
                }
                int Rep = StrToInt(StrNumber);
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Right();
                //Debug.Log("right");
            }
            else if (code_Array[0] == "move_left")
            {
                string StrRep = code_Array[1];
                string StrNumber = "";
                for (int j = 0; j < StrRep.Length; j++)
                {
                    if ((StrRep[j] != '(') && (StrRep[j] != ')'))
                        StrNumber += StrRep[j];
                }
                int Rep = StrToInt(StrNumber);
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Left();
                //Debug.Log("left");   
            }
            else if (code_Array[0] == "move_up")
            {
                string StrRep = code_Array[1];
                string StrNumber = "";
                for (int j = 0; j < StrRep.Length; j++)
                {
                    if ((StrRep[j] != '(') && (StrRep[j] != ')'))
                        StrNumber += StrRep[j];
                }
                int Rep = StrToInt(StrNumber);
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Up();
                //Debug.Log("Up");   
            }
            else if (code_Array[0] == "move_down")
            {
                string StrRep = code_Array[1];
                string StrNumber = "";
                for (int j = 0; j < StrRep.Length; j++)
                {
                    if ((StrRep[j] != '(') && (StrRep[j] != ')'))
                        StrNumber += StrRep[j];
                }
                int Rep = StrToInt(StrNumber); ;
                for (int j = 0; j < Rep; j++)
                    HeroKnight.instance.Move_Down();
                //Debug.Log("Down");   
            }
            else
            {
                errorIndex = 0;
                // Debug.Log(errorIndex);
            }
        }    

        string output = "";
        string ErrorOutput = "";
        for (int i = 0; i < code_Array.Length; i++)
        {
            if(i != errorIndex)
            {
                output += code_Array[i];
                ErrorOutput += " ";
            }
            else
            {
                output += " ";
                ErrorOutput += code_Array[i];
            }
            
        }
        codeText.text = output;
        ErrorText.text = ErrorOutput;
       // Debug.Log(ErrorText.text);
      //  Debug.Log(codeText.text);
    }
}
