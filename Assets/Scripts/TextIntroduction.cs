using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextIntroduction : MonoBehaviour
{
    public bool anyKey;

    public KeyCode requiredKey = KeyCode.X;

    public bool CheckNextEnabled(KeyCode pressed)
    {
        return pressed == requiredKey && !anyKey || anyKey; 
        // si la tecla que toco es la musica requerida y no puede activarse con cualquier tecla
        // si toco alguna tecla y puede continuar
    }
}
