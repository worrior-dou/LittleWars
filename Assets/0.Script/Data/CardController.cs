using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private List<DataScript> datas;
    [SerializeField] private Card card;
    [SerializeField] private Transform parent;

    [SerializeField] private Transform createTrans;

    [SerializeField] private Arrow arrow;
    [SerializeField] private Transform parentArrow;

    float createDelay = 0;

    void Update()
    {
        createDelay += Time.deltaTime;
        if (createDelay > 2f)
        {
            if (parent.childCount > 4)
                return;
            createDelay = 0;
            int rand = Random.Range(0, datas.Count);
            Card c = Instantiate(card, parent);
            c.SetData(datas[rand], arrow, parentArrow);
            c.CreateTrans = createTrans;
        }
    }
}
