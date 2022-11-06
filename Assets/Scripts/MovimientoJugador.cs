using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovimientoJugador : MonoBehaviour
{
    public float movementSpeed;
    private CharacterController charController;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis("Vertical") * movementSpeed; //Character Controller aplica deltatime
        float horizInput = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
     }
}
