using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour {
	[SerializeField] private Text goldPriceText;
	[SerializeField] private Text bulletsValueText;
	[SerializeField] private Image bulletsImage;
	//[SerializeField] private Button soundButton;

	[SerializeField] private int goldPrice; 
	[SerializeField] private int bulletsValue; 
	[SerializeField] private Sprite bulletImageToDisplay;
    //[SerializeField] private AudioSource bulletSound; 

    public int itemGoldPrice { get { return goldPrice; } }
    public int itemBulletdValue { get { return bulletsValue; } }

    public static ItemBehaviour instance;

	void Start ()
	{
		instance = this;
		goldPriceText.text = goldPrice.ToString();
		bulletsValueText.text = bulletsValue.ToString();
		bulletsImage.sprite = bulletImageToDisplay;	
	}
	
}
