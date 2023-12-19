using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovimentoEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;

    Vector3 movement = new Vector3(-1f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
