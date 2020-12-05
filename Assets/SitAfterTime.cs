using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitAfterTime : MonoBehaviour
{

    [Header("Tiempo hasta sentarse solo")]
    public float timeToSitDownMax = 2f; //en segundos
    [Header("Accion del animator disparada")]
    public string animParam = "isSitting";

    Animator anim;

    [SerializeField]
    private float timeTositCurr = 0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!Input.anyKey && !anim.GetBool(animParam))
        {
            timeTositCurr += Time.deltaTime;
            if (timeTositCurr >= timeToSitDownMax)
            {
                GetComponent<PlayerControlCC_2>().Sit(true);
                timeTositCurr = 0f;
            }
        }
        else if(Input.anyKey)
            timeTositCurr = 0f;
    }
}
