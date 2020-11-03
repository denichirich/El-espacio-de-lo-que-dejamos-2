using UnityEngine;

public class AudioService : MonoBehaviour
{
    public static AudioService Instance;

    [SerializeField]
    AudioStorer _audioStorer = null;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if(_audioStorer == null)
        {
            Debug.LogError("Necesitas un audio storer", this);
        }
    }

    public void Play(string clipName)
    {
        var toPlay = _audioStorer.Audios.Find(audio => audio.Clip != null && audio.Clip.name == clipName);
        if (toPlay == null)
        {
            Debug.LogError("No se encuentra el audio con nombre " + clipName);
            return;
        }
        var go = new GameObject(toPlay.Clip.name);
        var source = go.AddComponent<AudioSource>();
        source.clip = toPlay.Clip;
        source.volume = toPlay.Volume;
        source.loop = toPlay.Loop;
        source.Play();
        if(!source.loop)
        {
            Destroy(go, source.clip.length);
        }
    }

    public void Stop(string clipName)
    {
        var sources = FindObjectsOfType<AudioSource>();
        for(int i = sources.Length - 1; i >= 0; --i)
        {
            if(sources[i].name == clipName)
            {
                Destroy(sources[i].gameObject);
            }
        }
    }
}
