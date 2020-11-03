using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    //Principal          
    private Camera m_Camera;
    private CharacterController m_CharacterController;
    public Transform target;
    public Transform pivot;
    private float turnSmoothVelocity;

    [Header("Variables de Movimiento")]     //Header nos permite poner un titulo a las variables en el inspector
    [SerializeField]                        //Nos permite ver en el inspector variables privada
    private float m_MoveSpeed = 5.0f;
    [SerializeField]
    private float m_JumpForce = 5.0f;
    [SerializeField]
    private float m_GravityForce = 9.807f;

    [Range(0.0f, 5.0f)]                     //Nos permite crear un rango en el inspector
    public float m_LookSensitivity = 1.0f;

    [Header("Debugging Variables")]
    [SerializeField]
    private float m_MouseX;
    [SerializeField]
    private float m_MouseY;

    [SerializeField]
    private Vector3 m_MoveDirection;

    private bool underwater;
    
    void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_CharacterController = this.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
       

    }

    void Update()
    {
        ThirdCamera();
        Movement();
    }

    private void ThirdCamera()
    {
        //Seguir al Target
        m_Camera.transform.position = Vector3.Lerp(m_Camera.transform.position, target.position, Time.deltaTime * 100);
        //Rotar la camara
        m_Camera.transform.rotation = target.rotation;
     

        // Recivo la entrada del mouse y la sensibilidad
        m_MouseX += Input.GetAxisRaw("Mouse X") * m_LookSensitivity;
        m_MouseY += Input.GetAxisRaw("Mouse Y") * m_LookSensitivity;

        // Limito MouseY entre -50 y 70
        m_MouseY = Mathf.Clamp(m_MouseY, -50.0f, 70.0f);

        // Pivot sigue al player
        Vector3 t = new Vector3(this.transform.position.x, this.transform.position.y + 1.0f, this.transform.position.z);
        pivot.position = Vector3.Lerp(pivot.position, t, Time.deltaTime * 100);
        
        // Roto el pivot
        pivot.rotation = Quaternion.Euler(-m_MouseY, m_MouseX, 0.0f); //esta manera es util si rotaramos los 3 eje
  
    }

    private void Movement()
    {
        // Recive la entrada de movimiento
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        // Esta el player en el suelo
        if (m_CharacterController.isGrounded && !underwater)
        {
            Vector3 forwardMovement = this.transform.forward * Mathf.Abs(vertical);
            Vector3 strafeMovement = m_Camera.transform.right * horizontal;
            // Convierte la entrad en Vector3
            m_MoveDirection = (forwardMovement + strafeMovement).normalized * m_MoveSpeed;

            // Si presiono space salto
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Load());
            }
        }

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; // Angulo del joystick
            targetAngle += m_Camera.transform.eulerAngles.y; // le sumo la camara
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        // Calculo y aplico gravedad al movimiento
        m_MoveDirection.y -= m_GravityForce * Time.deltaTime;

        // Envio informacion de movimiento al character controller
        m_CharacterController.Move(m_MoveDirection * Time.fixedDeltaTime);//fisedDeltaTime es mas suave que deltaTime
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(0.7f);
        m_MoveDirection.y = m_JumpForce; // Salto
        m_CharacterController.Move(m_MoveDirection * Time.fixedDeltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Agua")
        {
            underwater = true;
            // Recive la entrada de movimiento
            Vector3 forwardMovement = m_Camera.transform.forward * Input.GetAxisRaw("Vertical");//Esta es una forma de declarar variables privada internas en la funcion
            Vector3 strafeMovement = m_Camera.transform.right * Input.GetAxisRaw("Horizontal");
            // Convierte la entrad en Vector3
            m_MoveDirection = (forwardMovement + strafeMovement).normalized * (m_MoveSpeed / 3);
            // Si presiono space salto
            if (Input.GetButton("Fire1"))
            {
                m_MoveDirection.y += (m_GravityForce + m_JumpForce) * 3 * Time.deltaTime; // Floto
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Agua")
        {
            underwater = false;
            
        }
    }
}
