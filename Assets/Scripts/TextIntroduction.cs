using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextIntroduction : MonoBehaviour
{
    public bool anyKey;

    public KeyCode requiredKey = KeyCode.X;


    private void Start()
    {
        //ManagerIntroduccion.instance.textosIntro.Add(this);
        this.gameObject.SetActive(false);
    }


    public bool CheckNextEnabled(KeyCode pressed)
    {
        print(pressed == requiredKey && !anyKey || anyKey);
        return pressed == requiredKey && !anyKey || anyKey; 
        // si la tecla que toco es la musica requerida y no puede activarse con cualquier tecla
        // si toco alguna tecla y puede continuar
    }
}
