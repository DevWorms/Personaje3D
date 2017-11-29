using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bagman : MonoBehaviour {

    Animator anim;
    int jumpHash = Animator.StringToHash("Salto");
    int runStateHash = Animator.StringToHash("Base Layer.Corriendo");
    public Transform bagMan;
    public float velocidad=10f;
    public float speed = 10.0F; //Velocidad de movimiento
    public float rotationSpeed = 100.0F; //Velocidad de rotación

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);
        if (Input.GetKey("w"))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("corre", true);
            anim.SetFloat("Velocidad", velocidad);
            bagMan.Translate((velocidad * new Vector3(0, 0, 3)) * Time.deltaTime);
            
        }
        else if (Input.GetKey("s"))
        {
            anim.SetBool("corre", true);
            anim.SetBool("isIdle", false);
            anim.SetFloat("Velocidad", velocidad);
            //bagMan.Translate((velocidad * new Vector3(0, 0, -3)) * Time.deltaTime);
            bagMan.transform.Rotate((velocidad * new Vector3(0, 360, 0)) * Time.deltaTime);
        }
        else if (Input.GetKey("a"))
        {
            anim.SetBool("corre", true);
            anim.SetBool("isIdle", false);
            bagMan.transform.Rotate((rotationSpeed * new Vector3(0, -1, 0)) * Time.deltaTime);
            //bagMan.Translate((velocidad * new Vector3(-1, 0, 0)) * Time.deltaTime);
        }
        else if (Input.GetKey("d"))
        {
            anim.SetBool("corre", true);
            anim.SetBool("isIdle", false);
            bagMan.transform.Rotate((rotationSpeed * new Vector3(0, 1, 0)) * Time.deltaTime);
            //bagMan.Translate((velocidad * new Vector3(1, 0, 0)) * Time.deltaTime);
        }
        else if (Input.GetKey("a") && Input.GetKey("w"))
        {
            anim.SetBool("isIdle", false);
            bagMan.transform.Rotate((rotationSpeed * new Vector3(0, 1, 0)) * Time.deltaTime);
            bagMan.Translate((velocidad * new Vector3(-1, 0, 3)) * Time.deltaTime);

        }

        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("corre", false);
        }


        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space) && stateInfo.nameHash == runStateHash)
        {
            anim.SetTrigger(jumpHash);
        }


    }
}
