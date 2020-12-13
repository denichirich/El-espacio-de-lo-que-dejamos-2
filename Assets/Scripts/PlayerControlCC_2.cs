using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlCC_2 : MonoBehaviour
{
    public KeyCode keyToSit = KeyCode.X;
    public KeyCode keyToRun = KeyCode.LeftShift;


    public bool isSitting = false;

    Animator anim;
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;

    private float turnSmoothVel;


    /// <summary>
    /// estas dos variables son para controlar si se pueden usar los controles
    /// comienza inactivo en los 2
    /// </summary>
    public bool activeMovement = true;
    public bool activeSitting = true;


    //variable que agregue para correr
    //public int velCorrer;
    // 16/11 - cambio, ya estaba esto

    public float multipSprint = 1.9f; // esta variable es para la velocidad de correr
    public float sprintValue = 1.5f;

    [Header("Lista de objetos en el personaje")]
    public List<GameObject> CoralesEnOrden;

    public float horizontal = 0;
    public float vertical = 0;

    public Vector3 direction;

    //private void OnEnable()
    //{
    //    //NarrativeManager.instance.PreviousInteraction.AddListener(DisableComponent);
    //    //NarrativeManager.instance.PostInteraction.AddListener(EnableComponent);
    //}

    void Start()
    {
        this.anim = this.GetComponent<Animator>();

        //GameObject.FindObjectOfType<PlayerControlCC_2>();
        activeMovement = false;
        activeSitting = false;


        GameManagerActions.current.startGameEvent.AddListener(EnableComponent);
        NarrativeManager.instance.PreviousInteraction.AddListener(SetInteractingMode);
        NarrativeManager.instance.PostInteraction.AddListener(QuitInteractingMode);

        //GameManagerActions.current.startGameEvent.AddListener(EnableComponent);

        // cuando se toca el boton de entrar al juego
        this.Sit(true);
    }

    public void ActivateCoral()
    {
        if (!string.IsNullOrEmpty(GeneralInfo.selectedCantidadDePersonas) &&
            GeneralInfo.idxCantidadDePersonas != -1) // cambio acoplado a lo que necesiten
        {
            this.CoralesEnOrden[GeneralInfo.idxCantidadDePersonas].SetActive(true);
        }
    }

    public void SetInteractingMode()
    {
        this.anim.SetBool("isInteracting", true);
        this.DisableComponent();
    }

    public void QuitInteractingMode()
    {
        this.anim.SetBool("isInteracting", false);
        this.EnableComponent();
    }


    // Update is called once per frame
    void Update()
    {
        //this.timeTositCurr += Time.deltaTime;


        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");


        if (activeSitting)
        {
            bool switchSitting = Input.GetKeyDown(keyToSit);
            // me fijo si me sente o deje de sentarme para el animador
            // y el tipo de movimiento
            if (switchSitting)
                Sit(!anim.GetBool("isSitting"));
        }

        if (!activeMovement)
            return;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        sprintValue = Input.GetAxis("Sprint") != 0 ? multipSprint : 1;

        direction = new Vector3(horizontal, 0, vertical).normalized;
        //Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;




        //escuchador para correr
        //if (Input.GetKey(KeyCode.LeftShift)&& !isSitting)
        //{
        //    speed = velCorrer;
        //    if(vertical > 0)
        //    {
        //        anim.SetBool("estaCorriendo", true);
        //    }
        //}
        //else
        //{
        //    anim.SetBool("estaCorriendo", false);
        //}
        if (direction.magnitude >= 0.1f && !isSitting && activeMovement) // check constante
        {
            MovePlayer(sprintValue, direction);

        }
        else if (isSitting && (Input.GetAxisRaw("Horizontal") * Input.GetAxisRaw("Vertical") != 0)) // me quiero salir de estar sentado
        {
            ExitSittingState();
        }
        else
        {

            anim.SetBool("estaCorriendo", false);
        }


    }

    private void LateUpdate()
    {
        anim.SetFloat("VelX", (Input.GetAxisRaw("Horizontal")));
        anim.SetFloat("VelY", Input.GetAxisRaw("Vertical"));
    }

    void ExitSittingState()
    {
        //EnableComponent();
        print("saliendo del estado de sentado");
    }

    public void Sit(bool val)
    {
        isSitting = val;
        anim.SetBool("isSitting", isSitting);
        //DisableComponent();

    }

    void MovePlayer(float sprintVal, Vector3 direction)
    {
        if (sprintVal > 1)
        {                    //this.anim.speed = 1.3f;
            anim.SetBool("estaCorriendo", true);

        }
        else
            anim.SetBool("estaCorriendo", false);

        //this.anim.speed = 1;

        //calculo la rotacion que tiene que hacer el personaje
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        // angulo + offset basado en como esta la camara

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //para mover en la direccion correcta
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        controller.Move(moveDir.normalized * speed * sprintVal * Time.deltaTime);

    }
    void DisableComponent()
    {
        anim.SetFloat("VelX", 0);
        anim.SetFloat("VelY", 0);

        this.activeMovement = false;
        this.activeSitting = false;
    }

    void EnableComponent()
    {
        this.activeMovement = true;
        this.activeSitting = true;
    }
}
