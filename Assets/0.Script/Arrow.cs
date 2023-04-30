using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    [HideInInspector] bool isMy;

    [SerializeField] Sprite sprite;

    Image sr;
    float atk = 0;

    void Start()
    {
        sr = GetComponent<Image>();
        Destroy(gameObject,5f);
    }

    void Update()
    {
        //화살 방향
        if (isMy)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 250f);
            sr.transform.localScale = new Vector3(1, 1, 1);
            FindTarget("enemy");
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * 250f);
            sr.transform.localScale = new Vector3(-1, 1, 1);
            FindTarget("my");
        }
    }

    public void SetData(float atk, bool isMy)
    {
        this.atk = atk;
        this.isMy = isMy;
    }

    void FindTarget(string tag)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length != 0)
        {
            float dist = float.MaxValue;
            GameObject target = null;
            foreach (var item in objs)
            {
                float distance = Vector3.Distance(transform.position, item.transform.position);
                if (dist > distance)
                {
                    dist = distance;
                    target = item;
                }
            }

            if (target != null)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance < 250f)
                {
                    if (target.GetComponent<Character>())
                    {
                        target.GetComponent<Character>().Hit(atk);
                    }
                    else if (target.GetComponent<Enemy>())
                    {
                        target.GetComponent<Enemy>().Hit(atk);
                    }
                }
            }
        }
    }

    //닿으면 화살 삭제
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isMy)
        {
            if (collision.tag == "enemy")
            {
                Debug.Log("triggerOnEnemy");
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.tag == "my")
            {
                Debug.Log("triggerOnMy");
                Destroy(gameObject);
            }
        }
    }
}
