using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrSplitTest : MonoBehaviour
{
    string s = "move_right (10)  move_left (9)";

    string[] stringSperation = new string[] {"", "(", ")"};

    [ContextMenu("test")]
    private void Start() {
        var result = s.Split(stringSperation,   System.StringSplitOptions.None);
        foreach (var item in result){
            Debug.Log(item);
        }
    }

    
}
