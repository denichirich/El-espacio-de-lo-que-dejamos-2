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

    [Header("Instanciar uno o mas objetos con eventos")]
    public List<GameObject> prefabInteraccion;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != GeneralInfo.PLAYER_LAYER || wasActivated) //evita repetir
            return;

        RaycastHit auxObstaculos;

        //evito que haya un obstaculo en el medio para poder interactuar

        var rayCanInteract = new Ray(transform.position, other.transform.position);
        var rayval = Physics.Raycast(rayCanInteract, out auxObstaculos, GeneralInfo.TERRAIN_LAYER);

        //Debug.Log(auxObstaculos);
        //print(rayval);

        if (Input.GetKeyDown(interactionKey) && auxObstaculos.collider == null)
        {
            Debug.Log("Todo ok, no hay obstaculos, toque el input");

            NarrativeManager.instance.OnPrepairForInteraction(); // desactivo camara, movimiento, etc
            GameObject container = Instantiate<GameObject>(new GameObject(), Vector3.zero, Quaternion.identity);
            foreach (var item in prefabInteraccion)
            {
                Instantiate(item, transform.position, Quaternion.identity, container.transform);
                // nota:
                // necesito un script para guardar las posiciones y datos de camara?
                // estarian en todos los prefabs que quieran crear
            }
            active = wasActivated = true;
            this.enabled = false;
        }



    }
}
