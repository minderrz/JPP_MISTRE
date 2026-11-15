using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //movement tuning (editable in inspector)
    public float speed = 5.0f;
    public float turnSpeed = 100f;

    //Iput System action exposed in Inspector for binding (WASD/Arrowk keys)
    public InputAction MoveAction;
    public Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Enable the MoveAction so it starts reading input
       MoveAction.Enable(); 
    }

    // Update is called once per frame
    void Update()
    
    {
       // Read the 2D vector from the MoveAction (x: horizontal, y: vertical)
       moveInput = MoveAction.ReadValue<Vector2>(); 

       //Move forward/back along local z using the y component
       transform.Translate(Vector3.forward*Time.deltaTime*speed * moveInput.y);

       //Rotate around local Y (yaw) using the x component
       transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
    }
}
