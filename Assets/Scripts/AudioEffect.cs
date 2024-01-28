using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Audio_Settings audio_settings;
    [SerializeField] private Controller controller;
    [SerializeField] Dictionary<AudioSelect, AudioSource> audioSources = new Dictionary<AudioSelect, AudioSource>();

    private void Start()
    {
        Transform transform = this.transform;
        foreach (Audio_Setting audio_setting in audio_settings.settings)
        {
            AudioSource audioSource = new GameObject().AddComponent<AudioSource>();
            audioSource.gameObject.name = audio_setting.audioSelect.ToString();
            audioSource.transform.parent = transform;
            audioSource.clip = audio_setting.audioClip;
            audioSources.Add(audio_setting.audioSelect, audioSource);

        }

        controller.MoveAction += () =>
        {
            // PlayOneShot(AudioSelect.Move);

        };

        controller.JumpAction += () =>
        {
            Play(AudioSelect.Jump);
        };

        controller.RushUPAction += () =>
        {
            Play(AudioSelect.Rush);
        };
    }

    public void Play(AudioSelect audioSelect)
    {
        AudioSource audioSource;
        audioSources.TryGetValue(audioSelect, out audioSource);
        audioSource?.Play();
    }
    // public void PlayOneShot(AudioSelect audioSelect)
    // {
    //     AudioSource audioSource;
    //     audioSources.TryGetValue(audioSelect, out audioSource);
    //     if (audioSource.isPlaying) return;
    //     audioSource.Play();
    // }
}
