using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public Image playerImgLife;
    public Image enemyImgLife;
    public Text enemyLife;
    [SerializeField] private Text playerLife;
    [SerializeField] private Text goldText;
    [SerializeField] private Text armmount;

    public static HUDManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateLife(int value)
    {
        playerLife.text = value.ToString();
    }

    public void UpdateGold(int gold)
    {
        goldText.text = gold.ToString();
    }

    public void UpdateArmmount()
    {
        armmount.text = WeaponManager.instance.AmmounitionCurrent + "/" + WeaponManager.instance.AmmounitionMax;
    }
}
