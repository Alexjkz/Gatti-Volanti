using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _energia = 100;
    [SerializeField] private GameObject[] healthHearts;
    [SerializeField] private Slider energyBar;
    
    // Start is called before the first frame update
    void Start()
    {
        // Inizializzo la vita
        _health = healthHearts.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.value = _energia;
        _energia -= Time.deltaTime;

        if(_energia <= 0)
        {
            HealthDecrease();
            _energia = 10;
        }
        // Clampiamo l'energia a 100
        if(_energia >= 100)
        {
            _energia = 100;
        }

        if(_health <= 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("YouLost");
        }

    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("DamageObj"))
        {
            HealthDecrease();
            print($"Health: {_health}");
        }
        else if(other.gameObject.CompareTag("Cibo"))
        {
            _energia += 10;
            print($"Energia: {_energia}");
            other.gameObject.SetActive(false);
        }
    }

    void HealthDecrease()
    {
        healthHearts[_health].SetActive(false);
        _health--;
    }
}
