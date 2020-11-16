using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Terminar esta clase con el video de chadrtronic
    /// </summary>
    public static AudioManager instance { get; private set; }

    public AudioSource[] sources;
    // 0: music
    // 1: ambient
    // 2: sound effects

    // Start is called before the first frame update
    void Awake()
    {

        instance = this;


        //sources = this.GetComponents<AudioSource>();
    }

    public void PlayMusic(AudioClip clip, bool forcePlay)
    {
        if (!this.sources[0].isPlaying || forcePlay)
            this.sources[0].PlayOneShot(clip);
    }

    public void PlayAmbience(AudioClip clip)
    {
        this.sources[1].PlayOneShot(clip);
    }

    public void PlayEffect(AudioClip clip)
    {
        this.sources[2].PlayOneShot(clip);
    }


}
