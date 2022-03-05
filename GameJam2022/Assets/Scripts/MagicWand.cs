using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject magicWand;


    void OnTriggerEnter()
    {
        Destroy(gameObject);

    }
}
