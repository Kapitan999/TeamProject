using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Compiler : MonoBehaviour
{
    Button Run_button;
    Text codeText;
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
        

        //Not worked
        char[] separators = new char[]
        {
            ' ', ';'
        };
        //

        //string code = codeText.text;

        string[] code_Array = codeText.text.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);

        Debug.Log(code_Array.Length);

        for(int i = 0; i < code_Array.Length; i++)
        {
            //Debug.Log(code_Array[0]);
            
        }

        if (code_Array[0] == "move_right()")
        {
            HeroKnight.instance.Move_Right();
            Debug.Log("right");
        }

        foreach (var codeName in code_Array)
        {
            if (codeName == "move_right()")
            {
                HeroKnight.instance.Move_Right();
                Debug.Log("right");
            }
            else if (codeName == "move_left()")
            {
                Debug.Log("Left");
                HeroKnight.instance.Move_Left();
            }
        }

        
    }
}
