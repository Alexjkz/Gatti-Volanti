using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player_Movement : MonoBehaviour
{

    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] public float groundCheckDistance = 10f;

    private float _moveInput;

    private bool _jumpInput;

    
    private MyInputSystem input = null;

    private Rigidbody rigidbodyGatto;

    
    public bool isGrounded;


    private void Awake()
    {
        input = new MyInputSystem();

        rigidbodyGatto = GetComponent<Rigidbody>();

        // Configuro l'azione di movimento
        input.MyActionMap.Movement.performed += ctx => _moveInput = ctx.ReadValue<float>();
        input.MyActionMap.Movement.canceled += ctx => _moveInput = 0.0f;

        // Configuro l'azione di salto
        input.MyActionMap.Jump.performed += ctx => _jumpInput = true;
        input.MyActionMap.Jump.canceled += ctx => _jumpInput = false;

        // Infinite forward movement
        _moveInput = 1.0f;

    }

    private void OnEnable()
    {
        input.MyActionMap.Enable();
    }

    private void OnDisable()
    {
        input.MyActionMap.Disable();
    } 
    

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);

        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance))
        {
            if(hit.collider.gameObject.CompareTag("Stage"))
            {
                isGrounded = true;
            }
        }
        else
        {
            isGrounded = false;
        }

        Vector3 movement = new Vector3(_moveInput, 0.0f, 0.0f);

        transform.Translate(movement * _speed * Time.deltaTime);
        
        if(isGrounded && _jumpInput)
        {
            rigidbodyGatto.AddForce(new Vector3(0.0f, _jumpForce, 0.0f), ForceMode.Impulse);
            _jumpInput = false;
        }

    }

}


//---------- OLD CODE ----------

    //Movimento vecchio input system
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // bool jump = Input.GetKeyDown("space");
        // print(moveHorizontal);
