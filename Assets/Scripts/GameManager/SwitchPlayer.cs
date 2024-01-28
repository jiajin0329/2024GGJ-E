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
    [SerializeField] Vector3 soulFxOffset;

    public async void Enable(Info info)
    {
        enable = true;
        timer_text.gameObject.SetActive(false);
        timer = 5;
        //timer = (byte)UnityEngine.Random.Range(15, 31);
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
        for (byte i = 0; i < soulFx.Length; i++)
        {
            soulFx[i].transform.position = info.playerInfos[i].controller.transform.position + soulFxOffset;
            soulFx[i].gameObject.SetActive(true);
        }

        foreach (var playerInfo in info.playerInfos)
        {
            playerInfo.character_sprites.WhiteColor();
        }

        soulFx[0].transform.DOMove(info.playerInfos[1].controller.transform.position + soulFxOffset, 2f).SetUpdate(true);
        soulFx[1].transform.DOMove(info.playerInfos[0].controller.transform.position + soulFxOffset, 2f).SetUpdate(true);

        Time.timeScale = 0f;

        await UniTask.Delay(2000, true);
        
        Switch(info);
        Time.timeScale = 1f;

        for (byte i = 0; i < soulFx.Length; i++)
        {
            soulFx[i].gameObject.SetActive(false);
        }
    }
}
