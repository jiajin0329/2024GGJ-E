using UnityEngine;
using static Controller;

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
        head.material.color = character_SpriteSetting.color;
        body.material.color = character_SpriteSetting.color;
    }

    public void SwitchColor()
    {
        if (player_Type == Player_Type.Player1)
        {
            player_Type = Player_Type.Player2;
        }
        else
        {
            player_Type = Player_Type.Player1;
        }

        pc_control_setting = pc_controlSettings_data.settings[(int)player_Type];
    }
}
