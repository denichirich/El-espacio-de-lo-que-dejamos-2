using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPersonasController : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    public TMPro.TextMeshProUGUI textOverSliderHandle;

    [Header("Opciones mostradas")]
    public List<string> sliderPrintedValues;

    private void Start()
    {
        GeneralInfo.selectedCantidadDePersonas = sliderPrintedValues[0];
        GeneralInfo.idxCantidadDePersonas = Mathf.RoundToInt(slider.value);
    }

    // Start is called before the first frame update
    public void OnValueChange()
    {
        textOverSliderHandle.text = sliderPrintedValues[Mathf.RoundToInt(slider.value)];
        print("cambiando slider " + textOverSliderHandle.text);

        GeneralInfo.selectedCantidadDePersonas = textOverSliderHandle.text;
        GeneralInfo.idxCantidadDePersonas = Mathf.RoundToInt(slider.value);
        print(textOverSliderHandle.text + " personas seleccionado.");
        //sobre general info guardo lo que necesite de respuestas del jugador
    }


}
