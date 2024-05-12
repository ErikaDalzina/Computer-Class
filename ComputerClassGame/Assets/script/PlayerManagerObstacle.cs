using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerObstacle : MonoBehaviour
{
    // global variables
    [SerializeField] float Foward_Initial_Speed;
    [SerializeField] float Foward_Max_Speed;
    [SerializeField] float Horizontal_Speed;

    float Horizontal;
    float Vertical;
    bool crash;

    Rigidbody rb;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region FowardMove
        if(crash == false)
        {
            if(rb.velocity.magnitude < Foward_Max_Speed)
            {
                rb.AddForce(0,0,Foward_Initial_Speed);    
            }
            else
            {
                rb.velocity = new Vector3(0,0,Foward_Max_Speed);
            }
        }
        else{rb.velocity = Vector3.zero;}
        #endregion
        Horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;

        PlayerMove(Horizontal,Horizontal_Speed);
        //end of update
    }

    //Collisions

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "FinishLine")
        {
            crash = true;
        }
    }

    //Functions
    void PlayerMove(float Horizontal, float Horizontal_Speed)
    {
        if(Horizontal != 0)
        {
            transform.Translate(Horizontal * Horizontal_Speed,0,0);
        }
    }
    //end of class
}
