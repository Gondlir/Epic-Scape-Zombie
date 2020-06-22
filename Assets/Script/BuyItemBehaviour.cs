using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BuyItemBehaviour : MonoBehaviour, IBuyItemBehaviour
{
    public static BuyItemBehaviour _instance;
    public int myCurrentGold { get { return Player.instance.Gold; } }
    public int goldPriceValue { get { return ItemBehaviour.instance.itemGoldPrice; } }
    public int goldLoss;
    public int goldValue;
    public void Start() 
    {
        _instance = this;
    }

    public void BuyItems(int goldPrice, int bulletsAmount)
    {
        if (goldPrice >= myCurrentGold)
        {
            Debug.Log("Cannot Buy");       
        }
        else if (goldPrice < myCurrentGold) 
        {
            Debug.Log("Can Buy");
            goldLoss = myCurrentGold;
            goldValue = goldLoss - goldPrice;
            Player.instance.Gold = goldValue;
            WeaponManager.instance.AmmounitionMax = bulletsAmount;
        }                
    }

    public void Equip()
    {
        HUDManager.instance.UpdateGold(goldValue);
        HUDManager.instance.UpdateArmmount();    
    }
}
