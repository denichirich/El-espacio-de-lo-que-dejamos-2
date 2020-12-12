using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPostEventCollection : MonoBehaviour
{
    /// <summary>
    /// en la lista tienen que cargar los gameobjects de luces que quieran que se prendan 
    /// post interaccion.
    /// esto se llama desde el interaction manager, y se pueden colgar un par de acciones mas que
    /// necesiten despues de elegir las personas en recuerdo.
    /// </summary>

    [Header("Lista de luces que estan como hijas de este objeto y otras que pongan aparte")]
    //[SerializeField]
    public List<GameObject> ListaLuces;

    // Start is called before the first frame update
    void Start()
    {
        
        foreach (var item in gameObject.GetComponentsInChildren<Transform>())
        {
            ListaLuces.Add(item.gameObject);

            item.gameObject.SetActive(false);
        }
    }

    public void ActivarLucesDeEscena()
    {
        if (ListaLuces != null)
        {
            Debug.Log("filled " + ListaLuces.Count);
            foreach (var luz in ListaLuces)
            {
                luz.SetActive(true);
            }
        }
    }
}
