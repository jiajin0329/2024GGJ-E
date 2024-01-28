
using System;
using UnityEngine;
[Serializable]
public class Character_SpriteSetting
{
    public Sprite head;
    public Sprite body;
    public Color color;
}

[CreateAssetMenu(fileName = "Character_SpriteSettings", menuName = "Character_SpriteSettings")]
public class Character_SpriteSettings : ScriptableObject {
    public Character_SpriteSetting[] settings;
}
