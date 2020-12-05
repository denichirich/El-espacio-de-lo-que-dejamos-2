using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiManagerDemo : MonoBehaviour
{
    public static GuiManagerDemo instance { get; private set; }

    public List<GameObject> alreadyActivated;

    private void Start()
    {
        if (instance == null)
            instance = this;

        alreadyActivated = new List<GameObject>();
    }

    public void SwitchGuiPlaya(bool val, GameObject targetCanvas)
    {
        targetCanvas.SetActive(val);
    }

    public void SwitchGuiNoRepeat(bool val, GameObject targetCanvas)
    {
        targetCanvas.SetActive(val && !alreadyActivated.Contains(targetCanvas));

        if (!alreadyActivated.Contains(targetCanvas))
        {
            alreadyActivated.Add(targetCanvas);
        }
    }

}
