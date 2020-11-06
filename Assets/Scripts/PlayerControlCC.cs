using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlCC : MonoBehaviour
{
    public KeyCode keyToSit = KeyCode.X;
    bool isSitting = false;

    public Animator anim;
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;

    public float multipSprint = 1.9f;


    private float turnSmoothVel;
    private bool active = true;

    private void OnEnable()
    {
        //NarrativeManager.instance.PreviousInteraction.AddListener(DisableComponent);
        //NarrativeManager.instance.PostInteraction.AddListener(EnableComponent);

    }
    // Start is called before the first frame update
    void Start()
    {
        this.anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
            return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        bool switchSitting = Input.GetKeyDown(keyToSit);

        // me fijo si me sente o deje de sentarme para el animador
        // y el tipo de movimiento

        if (switchSitting)
        {
            isSitting = !isSitting;
            anim.SetBool("isSitting", isSitting);
        }

        var sprintVal = Input.GetAxis("Sprint") != 0 ? multipSprint : 1;

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f && !isSitting) // check constante
        {
            MovePlayer(sprintVal, direction);
        }
        else if (isSitting && (horizontal * vertical != 0)) // me quiero salir de estar sentado
        {
            ExitSittingState();
        }

        anim.SetFloat("VelX", horizontal);
        anim.SetFloat("VelY", vertical);
    }
    void ExitSittingState()
    {
        print("saliendo del estado de sentado");

    }
    void MovePlayer(float sprintVal, Vector3 direction)
    {
        if (sprintVal != 1) // muuy primitivo pero ahora nos sirve para usar la misma animacion de caminar
            this.anim.speed = 1.3f;
        else
            this.anim.speed = 1;

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

        this.active = false;
    }

    void EnableComponent()
    {
        this.active = true;
    }
}
