using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 5f;
    [SerializeField] float bostSpeed = 90f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    Boolean canMove = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(canMove) {
            RotatePlayer();
            BostPlayer();
       }
    }

    public void DisableControls() {
        canMove = false;
    }


    void BostPlayer() {
        if(Input.GetKey(KeyCode.Space)) {
           surfaceEffector2D.speed = bostSpeed;
        } else {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer() {
          if(Input.GetKey(KeyCode.LeftArrow)) {
            rb2d.AddTorque(torqueAmount);
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
