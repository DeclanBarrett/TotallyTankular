using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ClickAudio : MonoBehaviour
{
    public AudioClip clickSoundEffect;
    // Start is called before the first frame update
    private AudioSource buttonAudio;

    void Start()
    {
        buttonAudio = this.gameObject.AddComponent<AudioSource>();
    }

    public void PlayClick()
    {
        buttonAudio.PlayOneShot(clickSoundEffect);
    }
}
