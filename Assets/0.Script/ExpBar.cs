using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Image costImage;
    //[SerializeField] private RectTransform rectTCost;
    [SerializeField] private TMP_Text txtCoin;

    float cost;
    float Max = 100f;

    float Cost
    {
        get { return cost; }
        set
        {
            cost = value;
            costImage.fillAmount = cost * 0.01f;
            //rectTCost.sizeDelta = new Vector2(w, 60f);
            txtCoin.text = ((int)cost).ToString();
        }
    }

    public static ExpBar Instance;

    void Awake() => Instance = this;

    void Start()
    {
        cost = 0;
    }

    void Update()
    {
        Cost += Time.deltaTime * 20f;
        if (Cost >= Max)
        {
            Cost = Max;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            float tempCost = Random.Range(10f,50f);
            if (Cost >= tempCost)
            {
                Cost -= tempCost;
            }
        }
    }

    public void SetCost(float cost, UnityAction action)
    {
        if (Cost >= cost)
        {
            Cost -= cost;
            action();
        }
    }
}
