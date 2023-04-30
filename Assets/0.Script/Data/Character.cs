using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    CharSpriteCont.SpriteData sprite;    
    DataScript data;

    [SerializeField] Image sr;

    float hp = 10;
    float atkTimer;
    bool isAttack = false;

    Arrow arrow;
    Transform parentArrow;
    void Update()
    {
        if (data == null)
        {
            return;
        }
        if (isAttack == false)
        {
            Move();
        }
    }

    public void SetData(DataScript data, Arrow arrow, Transform aParent)
    {
        this.data = data;
        hp = data.Hp;
        this.arrow = arrow;
        this.parentArrow = aParent;

        CharSpriteCont.CharacterSprite type = CharSpriteCont.CharacterSprite.Lv1_Sword;

        switch(data.Name)
        {
            case "Archor":
                type = CharSpriteCont.CharacterSprite.Lv1_Archor;
                Debug.Log("A");
                break;
            case "Guard":
                type = CharSpriteCont.CharacterSprite.Lv1_Guard;
                Debug.Log("G");
                break;
            case "Sword":
                type = CharSpriteCont.CharacterSprite.Lv1_Sword;
                Debug.Log("S");
                break;
        }

        sprite = CharSpriteCont.Instance.spriteDatas[(int)type];
        sr.sprite = sprite.idle;
    }
    void Move()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");

        Enemy e = null;
        float dist = float.MaxValue;
        for (int i = 0; i < objs.Length; i++)
        {
            //거리 체크
            float distance = Vector3.Distance(transform.position, objs[i].transform.position);
            if (dist > distance)
            {
                dist = distance;
                e = objs[i].GetComponent<Enemy>();
            }
        }

        if (e == null)
        {
            //그냥 무빙
            transform.Translate(Vector3.right * Time.deltaTime * data.Speed);
            sr.sprite = sprite.idle;
        }
        else
        {
            //근접거리 찾고 공격
            float distance = Vector3.Distance(transform.position, e.transform.position);
            if (distance > data.AtkRange)
            {
                transform.Translate(Vector3.right * Time.deltaTime * data.Speed);
                sr.sprite = sprite.idle;
            }
            else
            {
                sr.sprite = sprite.idle;
                atkTimer += Time.deltaTime;
                if (atkTimer > data.AtkDelay)
                {
                    atkTimer = 0;
                    isAttack = true;
                    sr.sprite = sprite.attack;
                    //화살 생성
                    if (data.Name != "Archor")
                    {
                        e.Hit(data.Atk);
                    }
                    else
                    {
                        //화살 생성
                        Arrow a = Instantiate(arrow, parentArrow);
                        Debug.Log("shoot!");
                        //화살위치 배정
                        a.transform.SetParent(transform);
                        a.transform.localPosition = Vector3.zero;
                        a.SetData(data.Atk, true);
                        //Destory를 위해 부모 변경
                        a.transform.SetParent(parentArrow);
                        e.Hit(data.Atk);
                    }
                    Invoke("IsAttackFalse", 0.2f);
                }
            }
        }
    }

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp>0)
        {
            sr.sprite = sprite.hit;
            Invoke("SetSpriteIdel", 0.1f);
        }
        else
        {
            sr.sprite = sprite.idle;
            Destroy(gameObject, 1f);
        }        
    }
    void IsAttackFalse()
    {
        isAttack = false;
    }

    void SetSpriteIdel()
    {
        sr.sprite = sprite.idle;
    }
}
