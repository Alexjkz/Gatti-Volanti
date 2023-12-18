using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGatto;
    [SerializeField] private GameObject prefabStage;
    private Coroutine MyCoroutineInstance;
    [SerializeField] private bool isReached = false;
    
    // Start is called before the first frame update
    void Start()
    {
        MyCoroutineInstance = StartCoroutine(GenerazioneProceduraleMondo());
    }

    // Update is called once per frame
    void Update()
    {
        if(playerGatto.transform.position.x > 20)
        {
            MyCoroutineInstance = StartCoroutine(GenerazioneProceduraleMondo());
        }
        print(playerGatto.transform.position.x);
    }

    IEnumerator GenerazioneProceduraleMondo()
    {
        GameObject newObject = Instantiate(prefabStage, new Vector3(20, 0, 0.5f), Quaternion.identity);
        
        yield return new WaitUntil(() => isReached);
    }
}
