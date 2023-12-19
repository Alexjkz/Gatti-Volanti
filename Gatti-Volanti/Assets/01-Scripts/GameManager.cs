using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGatto;
    [SerializeField] private GameObject prefabStage;
    private Coroutine MyCoroutineInstance;
    [SerializeField] private bool isReached = false;
    [SerializeField] GameObject[] nemici;
    [SerializeField] GameObject[] piattaforme;
    private float spawnPoint; // Offset di partenza per lo spawn del nuovo stage
    private float stageWidth = 20f; // Sarebbe bello che li calcolasse lui in base alla dimensione dello stage
    private float stageOffset;

    private float triggerStageOffset = 1f;
    private GameObject[] stages;

    private GameObject[] instantiatedEnemies;
    private int instEnemiesCounter = 0;
    private GameObject[] instantiatedPlatforms;
    private int instPlatformsCounter = 0;

    
    
    private int stageCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Qui mi salvo lo spawn point del gatto
        spawnPoint = playerGatto.transform.position.x;
        print("SpawnPoint: " + spawnPoint);
        
        // Inizializzo lo spawn offset
        stageOffset = 20;

        // Inizializzo il trigger offset
        triggerStageOffset = -12;

        // Inizializzo l'array di stage
        stages = new GameObject[80];

        // Inizializzo l'array di nemici
        instantiatedEnemies = new GameObject[80];

        // Inizializzo l'array di piattaforme
        instantiatedPlatforms = new GameObject[80];
    }

    // Update is called once per frame
    void Update()
    {

        if(playerGatto.transform.position.x > triggerStageOffset)
        {
            CreaIlMondo();
            CreaOggettiScena();
            stageOffset += stageWidth;
            triggerStageOffset += stageWidth;
        }
        
    }


    void CreaIlMondo()
    {
        
        print($"Sto generando lo stage in {stageOffset}");
        stages[stageCounter] = Instantiate(prefabStage, new Vector3(stageOffset , 0, 0.5f), Quaternion.identity);
        stageCounter += 1;
        if (stageCounter > 3)
        {
            Destroy(stages[stageCounter-4]); 
        }
    }


    void CreaOggettiScena()
    {
        // Creo piattaforme su cui saltare


        // Creo nemici
        instantiatedEnemies[instEnemiesCounter] = Instantiate(nemici[Random.Range(0, nemici.Length)], new Vector3(spawnPoint + stageOffset + Random.Range(0, stageWidth), 0, 0), Quaternion.identity);

    }


    // Meccanica della fame del gatto
    // Mangia gli oggetti "palle di pelo"

    // Niente re-spawn, il gatto muore e si ricomincia da capo
    
}


// ----------- ALTRO ----------


    // IEnumerator GenerazioneProceduraleMondo()
    // {
    //     print("Sto generando lo stage");
    //     GameObject newObject = Instantiate(prefabStage, new Vector3(spawnPoint + stageOffset , 0, 0.5f), Quaternion.identity);
    //     yield return new WaitUntil(() => isReached);
    // }


// Meccanica per gestione vita:
/*
Il gatto ha due parametri: fame e vita
La fame diminuisce col tempo
La vita diminuisce se la fame è a 0

Il gatto può mangiare gomitoli per aumentare la fame


*/