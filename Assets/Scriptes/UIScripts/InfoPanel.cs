using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{

    public static InfoPanel instance; 


    public GameObject ConsumPanel;
    public GameObject InventoryPanel;
    public Text GemsCount;
    private ConsumItem[] consumItems = new ConsumItem[3];
    private Inventory[] inventories = new Inventory[3];
    private int gems;
    private Text nameText;
    private Text infoText;
    private Text cost;
    private Button BuyBtn;
    void Start()
    {

        instance = this;


        nameText = gameObject.transform.GetChild(1).GetComponent<Text>();
        infoText = gameObject.transform.GetChild(2).GetComponent<Text>();
        cost = gameObject.transform.GetChild(3).GetChild(1).GetComponent<Text>();
        gems = int.Parse(GemsCount.text);
        for(int i = 0; i < consumItems.Length; i++)
        {
            consumItems[i] = ConsumPanel.transform.GetChild(i).GetComponent<ConsumItem>();
        }
        for (int i = 0; i < inventories.Length; i++)
        {
            inventories[i] = InventoryPanel.transform.GetChild(i).GetComponent<Inventory>();
        }


        BuyBtn = gameObject.transform.GetChild(4).GetComponent<Button>();
        BuyBtn.onClick.AddListener(Buy);
    }


    void ShowInfo(ConsumItem Item)
    {
        nameText.text = Item.ConsName;
        infoText.text = Item.info;
        cost.text = Item.cost.ToString();
    }

    public void Open(string ConsName)
    {
        for (int i = 0; i < consumItems.Length; i++)
        {
            if(consumItems[i].ConsName == ConsName)
            {
                ShowInfo(consumItems[i]);
                gameObject.transform.localScale = Vector3.one;
            }
        }
        
    }


    void Buy()
    {
        gems -= int.Parse(cost.text);
        GemsCount.text = gems.ToString();
        for (int i = 0; i < inventories.Length; i++)
        {
            if(inventories[i].ConsName == nameText.text)
            {
                inventories[i].count += 1;
                //inventories[i].image.color
                inventories[i].text.text = inventories[i].count.ToString();
            }
        }
    }
}
