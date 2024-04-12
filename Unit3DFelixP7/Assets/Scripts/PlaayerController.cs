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
        prb.AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
