using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggersInteraction : MonoBehaviour
{
    [Header("Configurable por codigo via opciones")]
    public KeyCode interactionKey = KeyCode.E;
    [Header("Rango para interactuar con este objeto")]
    public Collider colTriggerEnabled;

    /// <summary>
    /// Para manejar los estados despues de haber interactuado con un objeto.
    /// vemos si quieren que se pueda reactivar o que quede inutilizable.
    /// </summary>
    private bool active = false;
    private bool wasActivated = false;

    [Header("Activar uno o mas objetos con eventos")]
    public List<GameObject> ActivadosEnInteraccion;

    private bool isEnabledToInteract;


    bool CheckActor(Collider other)
    {
        if (other.gameObject.layer != GeneralInfo.PLAYER_LAYER || wasActivated) //evita repetir
        {
            return false;
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (CheckActor(other))
        {
            isEnabledToInteract = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        print("ex " + other.gameObject.name);

        if (CheckActor(other))
        {
            isEnabledToInteract = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactionKey))
            print("touch");

        if (Input.GetKeyDown(interactionKey) && isEnabledToInteract)
        {

            Debug.Log("Todo ok, no hay obstaculos, toque el input");

            NarrativeManager.instance.OnPrepairForInteraction(); // desactivo camara, movimiento, etc
            GameObject container = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
            foreach (var item in ActivadosEnInteraccion)
            {
                //Instantiate(item, transform.position, Quaternion.identity, container.transform);

                item.SetActive(true);

                // nota:
                // necesito un script para guardar las posiciones y datos de camara?
                // estarian en todos los prefabs que quieran crear
                // - hecho 6/11
            }
            active = wasActivated = true;
            this.enabled = false;
        }



    }
}
