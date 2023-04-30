using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct HpUI
{
    public Image imageHP;
    public TMP_Text txtHP;

    [HideInInspector] public float maxHP;
    [HideInInspector] public float curHP;

    //°­»ç´ÔÄÚµå
    public float ChangeHP
    {
        get { return curHP; }
        set {
            curHP = value;  
            imageHP.fillAmount =curHP / maxHP;
            //float sizeX = (curHP / maxHP) * 360f;
            //imageHP.GetComponent<RectTransform>().sizeDelta = new Vector3(sizeX, 60f);
            txtHP.text = curHP.ToString();
        }
    }
}

public class HpBar: MonoBehaviour
{
    [SerializeField] private HpUI hpUI_me;
    [SerializeField] private HpUI hpUI_enemy;
/*
    public float ChangeHP_me
    {
        private get { return hpUI_me.curHP; }
        set
        {
            hpUI_me.curHP = value;
            hpUI_me.imageHP.fillAmount = hpUI_me.curHP / hpUI_me.maxHP;
            // imageHp.fillAmount = curHP / maxHP;
        }
    }
    public float ChangeHP_enemy
    {
        private get { return hpUI_enemy.curHP; }
        set
        {
            hpUI_enemy.curHP = value;
            hpUI_enemy.imageHP.fillAmount = hpUI_enemy.curHP / hpUI_enemy.maxHP;
            // imageHp.fillAmount = curHP / maxHP;
        }
    }*/

    void Start()
    {
        //me
        hpUI_me.curHP = hpUI_me.maxHP = 20;
        hpUI_me.txtHP.text = hpUI_me.curHP.ToString();

        //enemy
        hpUI_enemy.curHP = hpUI_enemy.maxHP = 20;
        hpUI_enemy.txtHP.text = hpUI_enemy.curHP.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (hpUI_me.curHP > 0)
            {
                hpUI_me.ChangeHP -= 1;
            }            
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (hpUI_enemy.curHP > 0)
            {
                hpUI_enemy.ChangeHP -= 1;
            }            
        }
    }
}
