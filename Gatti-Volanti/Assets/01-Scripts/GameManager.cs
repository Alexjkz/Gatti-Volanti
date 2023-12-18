using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGatto;
    [SerializeField] private GameObject prefabStage;
    private Coroutine MyCoroutineInstance;
    [SerializeField] private bool isReached = false;
    private float spawnPoint;
    private float stageLength;
    
    // Start is called before the first frame update
    void Start()
    {
        stageLength = prefabStage.GetComponent<Renderer>().bounds.size.x;

        MyCoroutineInstance = StartCoroutine(GenerazioneProceduraleMondo());

        spawnPoint = playerGatto.transform.position.x;

        MyCoroutineInstance = StartCoroutine(GenerazioneProceduraleMondo());
    }

    // Update is called once per frame
    void Update()
    {
        if(playerGatto.transform.position.x >= spawnPoint - stageLength)
        {
            spawnPoint += stageLength;
            MyCoroutineInstance = StartCoroutine(GenerazioneProceduraleMondo());
        }
        print(playerGatto.transform.position.x);
    }

    IEnumerator GenerazioneProceduraleMondo()
    {
        GameObject newObject = Instantiate(prefabStage, new Vector3(spawnPoint + stageLength/2 , 0, 0.5f), Quaternion.identity);
        yield return new WaitUntil(() => isReached);
    }
}
