using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data", menuName ="Data/Data")]

public class DataScript : ScriptableObject
{
    [SerializeField] private string charName;
    public string Name { get { return charName; } }
    //아이콘
    [SerializeField] private Sprite sprite;
    public Sprite Icon { get { return sprite; } }    
    //체력
    [SerializeField] private float hp;
    public float Hp { get { return hp; } }
    //이동속도
    [SerializeField] private float speed;
    public float Speed { get { return speed; } }
    //공격력
    [SerializeField] private float atk;
    public float Atk { get { return atk; } }
    //공격범위
    [SerializeField] private float atkRange;
    public float AtkRange { get { return atkRange; } }
    //공격딜레이
    [SerializeField] private float atkDelay;
    public float AtkDelay { get { return atkDelay; } }
    //가격
    [SerializeField] private float cost;
    public float Cost { get { return cost; } }
    //캐릭터
    [SerializeField] private Character character;
    public Character Character { get { return character; } }
}
