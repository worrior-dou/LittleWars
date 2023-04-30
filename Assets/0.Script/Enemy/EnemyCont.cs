using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCont : MonoBehaviour
{
    public enum CharacterSprite
    {
        Lv1_Archor,
        Lv1_Guard,
        Lv1_Sword,
        Lv2_Archor,
        Lv2_Guard,
        Lv2_Sword,
    }

    [System.Serializable]
    public struct SpriteData
    {
        public Sprite idle;
        public Sprite attack;
        public Sprite hit;
        public Sprite die;
    }

    [System.Serializable]
    public struct Data
    {
        public DataScript charData;
        public SpriteData spriteDatas;
        public CharacterSprite type;
    }

    [SerializeField] private List<Data> datas;

    [SerializeField] private Enemy e;
    [SerializeField] private Transform parent;
    [SerializeField] private Arrow arrow;
    [SerializeField] private Transform parentArrow;

    float spawnTimer = 0;

    public static EnemyCont Instance;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Invoke();
        //설명: 함수이름, 처음시작 타이머, 몇초 마다 실행..
        InvokeRepeating("CreateEnemy", 3f, 3f);
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 3f)
        {
            spawnTimer = 0;
        }
    }

    void CreateEnemy()
    {
        Enemy e = Instantiate(this.e, parent);
        int rand = Random.Range(0, datas.Count);
        e.SetData(datas[rand], arrow, parentArrow);
    }
}
