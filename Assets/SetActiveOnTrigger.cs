using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnTrigger : MonoBehaviour
{
    public GameObject target;
    public bool requireInteracted = true;

    private void OnTriggerEnter(Collider other)
    {
        if (CheckActor(other) && requireInteracted && !string.IsNullOrEmpty(GeneralInfo.selectedCantidadDePersonas))
        {
            target.SetActive(true);
            Destroy(this.gameObject);
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
}
