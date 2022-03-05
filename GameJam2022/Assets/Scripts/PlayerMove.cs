using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speedforward = 5.0f;
    public float speedbackward = 3f;
    public float speedrun = 12f;
    public float rotateSpeed = 200f;
    public float jump = 3.0f;
    private float gravityValue = -9.81f;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded && velocity.y < 0){
            velocity.y = 0f;
        }

        /*transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);*/
        Rotation();
        transform.Rotate(0,currentYRotation,0);
        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        //float curSpeed = speed * Input.GetAxis("Vertical");
        MouvementForward();
        controller.SimpleMove(forward * curSpeed);

        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
           velocity.y += Mathf.Sqrt(jump * -3.0f * gravityValue);
        }
        velocity.y+= gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);  
    }

    private float curSpeed;
    public void MouvementForward(){
        if(Input.GetAxis("Vertical") !=0 && Input.GetButton("Run")){
            curSpeed = speedrun * Input.GetAxis("Vertical");
        }
        else if(Input.GetAxis("Vertical") > 0){
            curSpeed = speedforward * Input.GetAxis("Vertical");
        }else if (Input.GetAxis("Vertical") < 0){
            curSpeed = speedbackward * Input.GetAxis("Vertical");
        }
        else{
            curSpeed = 0;
        }
        Debug.Log(curSpeed);
    }

    private float smoothTime = 0.3f;
    private float yVelocity = 0.0f;
    private float currentYRotation;
    public void Rotation(){
        currentYRotation = Mathf.SmoothDamp(currentYRotation, Input.GetAxis("Horizontal") * rotateSpeed *Time.deltaTime, ref yVelocity, smoothTime);
        //currentYRotation = Input.GetAxis("Horizontal") * rotateSpeed *Time.deltaTime;
    }
}
