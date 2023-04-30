using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data", menuName ="Data/Data")]

public class DataScript : ScriptableObject
{
    [SerializeField] private string charName;
    public string Name { get { return charName; } }
    //������
    [SerializeField] private Sprite sprite;
    public Sprite Icon { get { return sprite; } }    
    //ü��
    [SerializeField] private float hp;
    public float Hp { get { return hp; } }
    //�̵��ӵ�
    [SerializeField] private float speed;
    public float Speed { get { return speed; } }
    //���ݷ�
    [SerializeField] private float atk;
    public float Atk { get { return atk; } }
    //���ݹ���
    [SerializeField] private float atkRange;
    public float AtkRange { get { return atkRange; } }
    //���ݵ�����
    [SerializeField] private float atkDelay;
    public float AtkDelay { get { return atkDelay; } }
    //����
    [SerializeField] private float cost;
    public float Cost { get { return cost; } }
    //ĳ����
    [SerializeField] private Character character;
    public Character Character { get { return character; } }
}
