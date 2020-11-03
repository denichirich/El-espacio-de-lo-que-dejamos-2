using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInteractionOnDisable : MonoBehaviour
{
    // Start is called before the first frame update
    void OnDisable()
    {
        NarrativeManager.instance.OnPostInteraction();
    }

}
