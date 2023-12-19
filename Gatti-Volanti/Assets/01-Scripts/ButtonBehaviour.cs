using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void PlayGame()
    {
       Debug.Log("Ho premuto il bottone");
       SceneManager.LoadScene("CityScene");
    }
}
