using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NarrativeManager : MonoBehaviour
{
    public static NarrativeManager instance; 

    public UnityEvent PreviousInteraction;
    public UnityEvent PostInteraction;

    public UnityEvent<string> TriggerAction;

    private void Awake()
    {
        if(instance == null || instance != this)
        {
            instance = this;
        }
    }

    // antes y despues de una interaccion limpio los eventos
    public void OnPrepairForInteraction()
    {
        if(PreviousInteraction != null)
        {
            instance.PreviousInteraction.Invoke();
            instance.PreviousInteraction = null;
        }
    }

    public void OnPostInteraction()
    {
        if (PostInteraction != null)
        {
            instance.PostInteraction.Invoke();
            instance.PostInteraction = null;

        }
    }
}
