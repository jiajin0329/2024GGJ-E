
using System;
using UnityEngine;
[Serializable]
public class Character_SpriteSetting
{
    public Sprite Head;
    public Sprite Body;  
}
[CreateAssetMenu(fileName = nameof(Character_SpriteSettings), menuName = nameof(Character_SpriteSettings))]
public class Character_SpriteSettings:ScriptableObject{
public Character_SpriteSetting[] character_SpriteSetting;
}
