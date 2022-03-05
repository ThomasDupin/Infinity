using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject cat;

  
    void OnTriggerEnter()
    {
        Destroy(gameObject);

    }


}
