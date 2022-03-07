using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speedforward = 5.0f;
    public float speedbackward = 3f;
    public float speedrun = 8f;
    public float rotateSpeed = 200f;
    public float jump = 3.0f;
    private float gravityValue = -9.81f;
    private Vector3 velocity;


    public bool isInteracted = false;
    public bool isInteractedPnj = false;
    public bool isInteractedPnj2 = false;
    public bool isInteractedRune2 = false;
    public bool isInteractedFriend = false;
    public bool isInteractedFriend2 = false;



    public string LevelName = "Village";
    public string LevelNameV = "Victory";

    private bool groundedPlayer;
    public HUD Hud;


    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        groundedPlayer = controller.isGrounded;
        

        if (groundedPlayer && velocity.y < 0){
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
        if( forward != Vector3.zero)
        {
            transform.forward = forward;
        }


        if (Input.GetButton("Jump") && groundedPlayer)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
           velocity.y += Mathf.Sqrt(jump * -3.0f * gravityValue);
        }
        velocity.y+= gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);  

        if ( isInteracted == true)
        {
           
            if (Input.GetButton("Interact"))
            {
                SceneManager.LoadScene(LevelName);
            }
          
        }

        if (isInteractedPnj == true)
        {

            if (Input.GetButton("Interact"))
            {
                Debug.Log("BLABLABLA VA CHERCHER MON CHAT FDP");
                Hud.OpenMessageDialoguePnj("");
            }

        }
        if (isInteractedPnj2 == true)
        {

            if (Input.GetButton("Interact"))
            {
                Debug.Log("baton magique lopsa");
                Hud.OpenMessageDialoguePnj2("");
            }

        }
        if (isInteractedRune2 == true)
        {

            if (Input.GetButton("Interact"))
            {

                SceneManager.LoadScene(LevelNameV); 
            }

        }
        if (isInteractedFriend == true)
        {

            if (Input.GetButton("Interact"))
            {
                Debug.Log("Salut mon amis bla bla bla les regles");
                
                Hud.OpenMessageDialogue("");
            }

        }
        if (isInteractedFriend2 == true)
        {

            if (Input.GetButton("Interact"))
            {
                Debug.Log("Re mon pote ");
                Hud.OpenMessageDialogue2("");
            }

        }


    }

    private float curSpeed;
    public void MouvementForward(){
        if(Input.GetAxis("Vertical") > 0 && Input.GetButton("Run")){
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
    }

    private float smoothTime = 0.5f;
    private float yVelocity = 0.0f;
    private float currentYRotation;
    public void Rotation(){
        //currentYRotation = Mathf.SmoothDamp(currentYRotation, Input.GetAxis("Horizontal") * rotateSpeed *Time.deltaTime, ref yVelocity, smoothTime);
        currentYRotation = Input.GetAxis("Horizontal") * rotateSpeed *Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="rune")
        {
            Hud.OpenMessagePanel("");
            isInteracted = true;
        } else if (other.tag=="Pnj")
        {
            Hud.OpenMessagePanel("");
            isInteractedPnj = true;

        }
        else if (other.tag == "Pnj2")
        {
            Hud.OpenMessagePanel("");
            isInteractedPnj2 = true;

        }
        else if (other.tag == "rune2")
        {
            if (GameObject.Find("cat") == null && GameObject.Find("wand") == null)
            {
                Hud.OpenMessagePanel("");
                isInteractedRune2 = true;
            }

        }
        else if (other.tag == "friend")
        {
                Hud.OpenMessagePanel("");
                isInteractedFriend = true;

        }
        else if (other.tag == "friend2")
        {
            Hud.OpenMessagePanel("");
            isInteractedFriend2 = true;


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "rune")
        {
            isInteracted = false;
            Hud.CloseMessagePanel();
        }
        if (other.tag == "Pnj")
        {
            isInteractedPnj = false;
            Hud.CloseMessagePanel();
        }
        if (other.tag == "Pnj2")
        {
            isInteractedPnj2 = false;
            Hud.CloseMessagePanel();
        }
        if (other.tag == "rune2")
        {

                isInteractedRune2 = false;
                Hud.CloseMessagePanel();
        }
        if (other.tag == "friend")
        {

            isInteractedFriend = false;
            Hud.CloseMessagePanel();
        }
        if (other.tag == "friend2")
        {

            isInteractedFriend2 = false;
            Hud.CloseMessagePanel();
        }


    }

}
