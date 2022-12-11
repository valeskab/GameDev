using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct ColorToSell
{
    public Color Color;
    public int price;
}
public class ShopBehaviourUI : MonoBehaviour
{
    [SerializeField] private GameObject skinColorButton;
    [SerializeField] private Transform skinColorParent;

    [SerializeField] private ColorToSell[] skinColors;

    private void Start()
    {
        for (int i = 0; i < skinColors.Length; i++)
        {
            Color color = skinColors[i].Color;
            int price = skinColors[i].price;
            
            GameObject newButton = Instantiate(skinColorButton,skinColorParent);
            newButton.transform.GetChild(0).GetComponent<Image>().color = color;
            newButton.transform.GetChild(1).GetComponent<Text>().text = price.ToString("#,#");
            //newButton.GetComponent<Button>().onClick.AddListener(() => PurchaseColor());
        }
    }

    public void PurchaseColor(Color color)
    {
        
    }
}
