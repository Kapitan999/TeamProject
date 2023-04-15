using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConsumItem : MonoBehaviour
{

    public string ConsName = "";
    public string info = "";
    public int cost = 0;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }


    void Clicked()
    {
        InfoPanel.instance.Open(ConsName);
    }
}
