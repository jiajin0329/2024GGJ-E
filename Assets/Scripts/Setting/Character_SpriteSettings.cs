
using System;
using UnityEngine;
[Serializable]
public class Character_SpriteSetting
{
    public Sprite head;
    public Sprite body;
}

[CreateAssetMenu(fileName = nameof(Character_SpriteSettings), menuName = nameof(Character_SpriteSettings))]
public class Character_SpriteSettings : ScriptableObject {
    public Character_SpriteSetting[] settings;
}
