using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private int _health = 9;
    [SerializeField] private float _energia = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _energia -= Time.deltaTime;

        if(_energia <= 0)
        {
            _health--;
            print($"Health: {_health}");
            _energia = 10;
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("DamageObj"))
        {
            _health--;
            print($"Health: {_health}");
        }
        else if(other.gameObject.CompareTag("Cibo"))
        {
            _energia += 10;
            print($"Energia: {_energia}");
            other.gameObject.SetActive(false);
        }
    }
}
