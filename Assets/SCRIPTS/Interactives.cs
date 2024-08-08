using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Interactives : MonoBehaviour
{
    public Animator button;
    public LayerMask ButtonHitBox;

    public bool canPressed;

    //private Backstabbing canStab;

    // Start is called before the first frame update
    void Start()
    {
        //canStab = GetComponent<Backstabbing>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, ButtonHitBox))
        {
            canPressed = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
        else
        {
            canPressed = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }

        if (Input.GetKey(KeyCode.Mouse0) && canPressed)
        {
            button.SetBool("ButtonPressed", true);
            Debug.Log("Interactive has found the code from Backstabbing!");
        }
    }
}
