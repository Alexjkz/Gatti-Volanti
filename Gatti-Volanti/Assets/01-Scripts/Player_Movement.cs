using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player_Movement : MonoBehaviour
{

    public float _speed = 10.0f;
    private float _jumpForce = 5.0f;

    private float _moveInput;

    private bool _jumpInput;

    
    private MyInputSystem input = null;

    private Rigidbody rigidbodyGatto;


    private void Awake()
    {
        print("Awake");
        input = new MyInputSystem();

        rigidbodyGatto = GetComponent<Rigidbody>();

        // Configuro l'azione di movimento
        input.MyActionMap.Movement.performed += ctx => _moveInput = ctx.ReadValue<float>();
        input.MyActionMap.Movement.canceled += ctx => _moveInput = 0.0f;

        // Configuro l'azione di salto
        input.MyActionMap.Jump.performed += ctx => _jumpInput = true;
        input.MyActionMap.Jump.canceled += ctx => _jumpInput = false;

    }

    private void OnEnable()
    {
        print("OnEnable");
        input.MyActionMap.Enable();
    }

    private void OnDisable()
    {
        print("OnDisable");
        input.MyActionMap.Disable();
    } 
    

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // bool jump = Input.GetKeyDown("space");
        // print(moveHorizontal);


        Vector3 movement = new Vector3(_moveInput, 0.0f, 0.0f);

        transform.Translate(movement * _speed * Time.deltaTime);
        
        if(_jumpInput)
        {
            rigidbodyGatto.AddForce(new Vector3(0.0f, _jumpForce, 0.0f), ForceMode.Impulse);
            _jumpInput = false;
        }

    }

}
