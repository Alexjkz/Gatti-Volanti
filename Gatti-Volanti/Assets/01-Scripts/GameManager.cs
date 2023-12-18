using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGatto;
    [SerializeField] private GameObject prefabStage;
    private Coroutine MyCoroutineInstance;
    [SerializeField] private bool isReached = false;
    private float spawnPoint; // Offset di partenza per lo spawn del nuovo stage
    private float stageWidth = 20f; // Sarebbe bello che li calcolasse lui in base alla dimensione dello stage
    private float stageOffset;

    private float triggerStageOffset = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Qui mi salvo lo spawn point del gatto
        spawnPoint = playerGatto.transform.position.x;
        print("SpawnPoint: " + spawnPoint);
        
        // Inizializzo lo spawn offset
        stageOffset = (stageWidth + spawnPoint) / 2;

        // Inizializzo il trigger offset
        triggerStageOffset = -12;
    }

    // Update is called once per frame
    void Update()
    {
        print($"Player: {playerGatto.transform.position.x} - Trigger: {triggerStageOffset}");

        if(playerGatto.transform.position.x > triggerStageOffset)
        {
            CreaIlMondo();
            stageOffset += stageWidth;
            triggerStageOffset += stageWidth;
        }
        
    }


    void CreaIlMondo()
    {
        print($"Sto generando lo stage in {stageOffset}");
        GameObject newObject = Instantiate(prefabStage, new Vector3(stageOffset , 0, 0.5f), Quaternion.identity);
    }
}


// ----------- ALTRO ----------


    // IEnumerator GenerazioneProceduraleMondo()
    // {
    //     print("Sto generando lo stage");
    //     GameObject newObject = Instantiate(prefabStage, new Vector3(spawnPoint + stageOffset , 0, 0.5f), Quaternion.identity);
    //     yield return new WaitUntil(() => isReached);
    // }