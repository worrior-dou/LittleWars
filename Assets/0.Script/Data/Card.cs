using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text txtHP;
    [SerializeField] private TMP_Text txtAtk;
    [SerializeField] private TMP_Text txtCost;

    DataScript data;
    Arrow arrow;
    Transform parentArrow;

    public Transform CreateTrans { get; set; }

    public void SetData(DataScript data, Arrow arrow, Transform parentArrow)
    {
        this.data = data;
        this.arrow = arrow;
        this.parentArrow = parentArrow;

        icon.sprite = data.Icon;
        txtHP.text = data.Hp.ToString();
        txtAtk.text = data.Atk.ToString();
        txtCost.text = data.Cost.ToString();        
    }
    public void Onclick()
    {
        ExpBar.Instance.SetCost(data.Cost, 
            () =>
            {
                Character c = Instantiate(data.Character, CreateTrans);
                c.SetData(data, arrow, parentArrow);
                Destroy(gameObject);
                Debug.Log("OnClick work");
            });
    }
}
