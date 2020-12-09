using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivateMenu : MonoBehaviour
{
    public GameObject menuAsociado;
    public bool canReactivate = true;

    private void OnTriggerEnter(Collider other)
    {
        if (CheckActor(other))
        {
            Debug.Log("entrando playa");
            GuiManagerDemo.instance.SwitchGuiPlaya(true, menuAsociado);
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
                GuiManagerDemo.instance.SwitchGuiPlaya(false, menuAsociado);
        }


    }
}
