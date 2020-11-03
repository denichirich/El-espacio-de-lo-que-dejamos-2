using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AudioDefinition
{
    public AudioClip Clip = null;
    [Range(0f, 1f)]
    public float Volume = 1f;
    public bool Loop = false;
}

[CreateAssetMenu]
public class AudioStorer : ScriptableObject
{
    public List<AudioDefinition> Audios = new List<AudioDefinition>();
}
