using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Backstabbing : MonoBehaviour
{
    public LayerMask StabHitBox;
    //public Animator animator;

    public bool canStab;
    public GameObject stabbedText;

    [SerializeField]
    private float timerStabbedText = 300f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        #region Backstab Detection
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, 1f, StabHitBox))
        {
            Debug.Log("Can Backstab!");
            canStab = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            Debug.Log("Cannot Backstab!");
            canStab = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        #endregion

        #region Backstab Registration
        if(Input.GetKey(KeyCode.Mouse0) && canStab)
        {
            stabbedText.SetActive(true);
            Destroy(hit.transform.gameObject);
            //RemoveStabbedText();
        }

        #endregion

        
    }

    /*#region Stabbed Text
    void RemoveStabbedText()
    {
        while (timerStabbedText > 0f)
        {
            timerStabbedText -= Time.deltaTime;
        }

        if(timerStabbedText <= 0f)
        {
            stabbedText.SetActive(false);
        }
    }
    #endregion*/
}
