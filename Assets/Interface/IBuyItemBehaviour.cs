using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuyItemBehaviour  
{
	void BuyItems(int currentGoldValue, int bulletsAmount);
	void Equip();
}
