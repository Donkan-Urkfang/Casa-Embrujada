using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class MovimientoJugador : MonoBehaviour
{
    public float movementSpeed;
    private CharacterController charController;
    public Animator animacion;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
        Animaciones();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis("Vertical") * movementSpeed; //Character Controller aplica deltatime
        float horizInput = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
     }

    private void Animaciones(){

        if (Input.GetKey(KeyCode.W)){
            animacion.SetBool("Avanzar", true);
        } else {
            animacion.SetBool("Avanzar", false);
        }
        
        if (Input.GetKey(KeyCode.A)){
            animacion.SetBool("Izquierda", true);
        } else {
            animacion.SetBool("Izquierda", false);
        }
        
        if (Input.GetKey(KeyCode.D)){
            animacion.SetBool("Derecha", true);
        } else {
            animacion.SetBool("Derecha", false);
        }
        
        if (Input.GetKey(KeyCode.S)){
            animacion.SetBool("Retroceder", true);
        } else {
            animacion.SetBool("Retroceder", false);
        }
    }
}
