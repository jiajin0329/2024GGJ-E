using Cysharp.Threading.Tasks;
using TMPro;
using System;
using UnityEngine;
using DG.Tweening;

[Serializable]
public class SwitchPlayer {
    public bool enable;

    [SerializeField] private TextMeshProUGUI timer_text;
    private byte timer;

    [SerializeField] ParticleSystem[] soulFx;

    public async void Enable(Info info)
    {
        enable = true;
        timer_text.gameObject.SetActive(false);
        //timer = 5;
        timer = (byte)UnityEngine.Random.Range(15, 31);
        while (enable)
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
                SwitchSoul(info);
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

    private async void SwitchSoul(Info info)
    {
        Time.timeScale = 0f;

        for (byte i = 0; i < soulFx.Length; i++)
        {
            soulFx[i].transform.position = info.playerInfos[i].controller.transform.position;
            soulFx[i].gameObject.SetActive(true);
        }

        soulFx[0].transform.DOMove(info.playerInfos[1].controller.transform.position, 2f);
        soulFx[1].transform.DOMove(info.playerInfos[0].controller.transform.position, 2f);

        await UniTask.Delay(2000);
        
        foreach (var playerInfo in info.playerInfos)
        {
            playerInfo.character_sprites.WhiteColor();
        }

        Switch(info);
    }
}
