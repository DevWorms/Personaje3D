using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camaraMovement : MonoBehaviour
{
    public GameObject spartan;
   

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        transform.position =    new Vector3(spartan.transform.position.x, spartan.transform.position.y+2.2f, spartan.transform.position.z- 10f);



    }
}

