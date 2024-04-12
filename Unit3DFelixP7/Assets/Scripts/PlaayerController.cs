using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaayerController : MonoBehaviour
{
    private Rigidbody prb;
    // Start is called before the first frame update
    void Start()
    {
        prb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
