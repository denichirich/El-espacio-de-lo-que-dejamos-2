using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivateMenu : MonoBehaviour
{
    public GameObject menuAsociado;

    private void OnTriggerEnter(Collider other)
    {
        if (CheckActor(other))

        {
            print("entro");

            GuiManagerDemo.instance.SwitchGuiPlaya(true);
        }
    }
    bool CheckActor(Collider other)
    {
        if (other.gameObject.layer != GeneralInfo.PLAYER_LAYER) //evita repetir
        {
            return false;
        }
        return true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckActor(other))
        {
            print("salio");
            GuiManagerDemo.instance.SwitchGuiPlaya(false);
        }


    }
}
