using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    [SerializeField] private Image imgLife;
    [SerializeField] private Text gold;
    [SerializeField] private Text armmount;

    public static HUDManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateLife()
    {
        float percentage = Player.instance.CurrentLife / Player.instance.MaxLife;
        imgLife.fillAmount = percentage;
    }

    public void UpdateGold()
    {
        gold.text = Player.instance.Gold.ToString();
    }

    public void UpdateArmmount()
    {
        armmount.text = WeaponManager.instance.AmmounitionCurrent + "/" + WeaponManager.instance.AmmounitionMax;
    }
}
