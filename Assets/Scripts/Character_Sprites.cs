using UnityEngine;

public class Character_Sprites : MonoBehaviour
{
    [SerializeField] SpriteRenderer head;
    [SerializeField] SpriteRenderer body;
    [SerializeField] Character_SpriteSettings character_SpriteSettings;
    [SerializeField] Controller controller;

    private Character_SpriteSetting character_SpriteSetting;

    private void Start()
    {
        character_SpriteSetting = character_SpriteSettings.settings[(int)controller.player_Type];
        head.sprite = character_SpriteSetting.head;
        body.sprite = character_SpriteSetting.body;
    }
}
