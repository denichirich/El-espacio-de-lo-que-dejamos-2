using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInteraccion1Tools : MonoBehaviour
{
    public GameObject CanvasDestruirConfirmado;
    public UnityEngine.UI.Slider slider;
    public AudioClip audioConfirm;
    // para evitar que lo rompan tocando solo el boton ok

    public void ConfirmSelection()
    {
        if (string.IsNullOrEmpty(GeneralInfo.selectedCantidadDePersonas))
        {
            GeneralInfo.selectedCantidadDePersonas = "Ninguna?";
            GeneralInfo.idxCantidadDePersonas = -1;

        }
        if (audioConfirm)
            AudioManager.instance.PlayEffect(audioConfirm);
        //tienen que aclararme que quieren que pase con esto.

        //Destroy(CanvasDestruirConfirmado);
        FindObjectOfType<PlayerControlCC_2>().ActivateCoral();

        NarrativeManager.instance.OnPostInteraction();

        CanvasDestruirConfirmado.SetActive(false);
    }
}
