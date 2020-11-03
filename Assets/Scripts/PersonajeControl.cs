using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeControl : MonoBehaviour
{

    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    public Animator anim;
    public float x, y;

    public bool tocandoRecuerdo;
    public bool avanzarSolo;

    void Start()
    {

        anim = GetComponent<Animator>();

    }


    void FixedUpdate ()
    {
        if(!tocandoRecuerdo)
        {
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);

            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        }

      /*  if(avanzarSolo)
        {
            rb.velocicity = transform.forward
        }*/

    }


    void Update()
    {

        x = Input.GetAxis("Horizontal");

        y = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Return) && !tocandoRecuerdo)
        {
            anim.SetTrigger("tocar");
            tocandoRecuerdo = true;
        }

        /*transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);

        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);*/
       

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

       }

    public void DejoDeTocar()
    {
        tocandoRecuerdo = false;
    }

    public void DejoDeAvanzar()
    {
        avanzarSolo = false;
    }
}
