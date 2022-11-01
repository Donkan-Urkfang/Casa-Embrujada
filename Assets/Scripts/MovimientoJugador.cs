using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovimientoJugador : MonoBehaviour
{
    private float movementSpeed;
    private CharacterController charController;
    public float RunSpeed = 10f;
    public float NormalSpeed = 2f;
    public bool isRunning = false;


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
        if (Input.GetKey(KeyCode.LeftShift)) {
             movementSpeed = RunSpeed;
        } else {
             movementSpeed = NormalSpeed;
        }

        float vertInput = Input.GetAxis("Vertical") * movementSpeed; //Character Controller aplica deltatime
        float horizInput = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
     }
}
