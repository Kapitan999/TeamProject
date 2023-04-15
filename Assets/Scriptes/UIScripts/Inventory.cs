using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public string ConsName = "";
    public int count = 0;
    public Image image;
    public Text text;

    private void Start()
    {
        text = gameObject.transform.GetChild(0).GetComponent<Text>();
        image = GetComponent<Image>();
    }
}
