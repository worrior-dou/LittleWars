
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpriteCont : MonoBehaviour
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

    public static CharSpriteCont Instance;
    public List<SpriteData> spriteDatas;

    void Awake()
    {
        Instance = this;
    }
}
