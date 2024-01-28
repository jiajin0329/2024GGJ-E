using Cysharp.Threading.Tasks;
using TMPro;
using System;
using UnityEngine;

[Serializable]
public class SwitchPlayer {
    public bool enable;

    [SerializeField] private TextMeshProUGUI timer_text;
    private byte timer;

    public async void Enable(Info info)
    {
        enable = true;
        timer_text.gameObject.SetActive(false);
        timer = 5;
        //timer = (byte)UnityEngine.Random.Range(15,31);
        while(enable)
        {
            await UniTask.Delay(1000);
            timer--;

            if (timer < 4)
            {
                timer_text.gameObject.SetActive(true);
                timer_text.text = timer.ToString();
            }
            
            if (timer == 0)
            {
                timer_text.gameObject.SetActive(false);
                Switch(info);
                Disenable();
            }
        }
    }

    public void Disenable()
    {
        enable = false;
    }

    private void Switch(Info info)
    {
        foreach (var playerInfo in info.playerInfos)
        {
            playerInfo.controller.SwitchControl();
            playerInfo.character_sprites.SwitchColor();
        }
    }
}
