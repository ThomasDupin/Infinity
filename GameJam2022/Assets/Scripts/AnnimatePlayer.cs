using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnimatePlayer : MonoBehaviour
{
    Animator Player;
    // Start is called before the first frame update
    void Awake()
    {
       Player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Player.SetFloat("walk",Input.GetAxis("Vertical"));
        Player.SetBool("run",Input.GetButton("Run"));
        Player.SetBool("jump",Input.GetButton("Jump"));
    }
}
