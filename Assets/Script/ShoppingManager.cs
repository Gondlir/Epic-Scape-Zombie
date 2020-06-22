using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class ShoppingManager : MonoBehaviour,IShoppingManagerBehaviour 
{
    public int goldPrice { get { return ItemBehaviour.instance.itemGoldPrice; } }
    public int bulletsToLoad { get { return ItemBehaviour.instance.itemBulletdValue; } }
    public int currentBullets{ get { return WeaponManager.instance.AmmounitionCurrent; } }
    public void Buy()
    {
        BuyItemBehaviour._instance.BuyItems(goldPrice, bulletsToLoad);     
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        BuyItemBehaviour._instance.Equip();
    }
}
