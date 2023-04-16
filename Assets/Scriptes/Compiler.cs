using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Compiler : MonoBehaviour
{
    Button Run_button;
    Text codeText;
    string code;
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
        code = codeText.text;
        if(code == "move_forvard()")
        {
            HeroKnight.instance.Test();
        }
    }
}
