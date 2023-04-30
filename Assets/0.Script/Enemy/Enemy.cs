using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    EnemyCont.Data data;
    float hp;
    Image sr;
    float atkTimer;
    bool isAttack = false;

    Arrow arrow;
    Transform parentArrow;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<Image>();//�̹��� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack == false)
        {
            Move();
        }
    }

    public void SetData(EnemyCont.Data data, Arrow arrow, Transform aParent)
    {
        this.data = data;
        hp = data.charData.Hp;
        this.arrow = arrow;
        this.parentArrow = aParent;
    }

    void Move()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("my");

        Character c = null;
        float dist = float.MaxValue;
        for (int i = 0; i < objs.Length; i++)
        {
            //�Ÿ� üũ
            float distance = Vector3.Distance(transform.position, objs[i].transform.position);
            if (dist > distance)
            {
                dist = distance;
                c = objs[i].GetComponent<Character>();
            }
        }

        if (c == null)
        {
            //�׳� ����
            transform.Translate(Vector3.left * Time.deltaTime * data.charData.Speed);
            sr.sprite = data.spriteDatas.idle;
        }
        else
        {
            //�����Ÿ� ��� ����
            float distance = Vector3.Distance(transform.position, c.transform.position);
            if (distance > data.charData.AtkRange)
            {
                transform.Translate(Vector3.left * Time.deltaTime * data.charData.Speed);
                sr.sprite = data.spriteDatas.idle;
            }
            else
            {
                sr.sprite = data.spriteDatas.idle;
                atkTimer += Time.deltaTime;
                if (atkTimer > data.charData.AtkDelay)
                {
                    atkTimer = 0;
                    isAttack = true;
                    sr.sprite = data.spriteDatas.attack;
                    //ȭ�� ����
                    if (data.charData.Name != "Archor")
                    {
                        c.Hit(data.charData.Atk);
                    }
                    else
                    {
                        //ȭ�� ����
                        Arrow a = Instantiate(arrow, parentArrow);
                        Debug.Log("shoot!");
                        //ȭ����ġ ����
                        a.transform.SetParent(transform);
                        a.transform.localPosition = Vector3.zero;                        
                        a.SetData(data.charData.Atk, false);
                        //Destory�� ���� �θ� ����
                        a.transform.SetParent(parentArrow);
                        c.Hit(data.charData.Atk);
                    }
                    Invoke("IsAttackFalse", 0.2f);
                }
            }
        }
    }

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp > 0)
        {
            sr.sprite = data.spriteDatas.hit;
            Invoke("SetSpriteIdel", 0.1f);
        }
        else
        {
            sr.sprite = data.spriteDatas.idle;
            Destroy(gameObject, 1f);
        }
    }

    void IsAttackFalse()
    {
        isAttack = false;
    }
    void SetSpriteIdel()
    {
        sr.sprite = data.spriteDatas.idle;
    }
}
