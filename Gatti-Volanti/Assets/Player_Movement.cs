using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Player_Movement : MonoBehaviour
{

    public float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool jump = Input.GetKeyDown("space");

        print(moveHorizontal);



        Vector3 movement = new Vector3(0.0f, moveHorizontal, 0.0f);
        Vector3 jumpTransform = new Vector3(-30.0f, 0.0f, 0.0f);

        transform.Translate(movement * _speed * Time.deltaTime);
        
        if(jump)
        {
            transform.Translate( jumpTransform * _speed * Time.deltaTime);
        }

    }



}
