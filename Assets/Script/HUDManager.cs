using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    [SerializeField] private Text gold;
    [SerializeField] private Text armmount;

    public static HUDManager instance;

    private void Awake()
    {
        instance = this;
    }
}
