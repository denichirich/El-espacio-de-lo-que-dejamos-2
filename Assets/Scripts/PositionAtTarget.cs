using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAtTarget : MonoBehaviour
{
    public GameObject target;
    public string byTag = "";

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
            transform.position = target.transform.position;
        if(!string.IsNullOrEmpty(byTag))
            transform.position = GameObject.FindGameObjectWithTag(byTag).transform.position;

    }
}
