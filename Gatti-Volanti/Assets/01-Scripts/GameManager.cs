using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGatto;
    [SerializeField] private GameObject prefabStage;
    private Coroutine MyCoroutineInstance;
    [SerializeField] private bool isReached = false;
    [SerializeField] GameObject[] nemici;
    [SerializeField] GameObject[] piattaforme;

    [SerializeField] GameObject[] oggettiCibo;
    [SerializeField] private TextMeshProUGUI fpsText;
    
    private float deltaTime;
    private float spawnPoint; // Offset di partenza per lo spawn del nuovo stage
    private float stageWidth = 20f; // Sarebbe bello che li calcolasse lui in base alla dimensione dello stage



    private GameObject[] instantiatedEnemies;
    private int instEnemiesCounter = 0;
    private GameObject[] instantiatedPlatforms;
    private int instPlatformsCounter = 0;
    public int stageProgression = 0;

    
    // >>> Gestione Stages <<<
    private GameObject[] stages; // Array che contiene tutti gli stages spawnati
    private int stageIndex = 0; // Mi tiene traccia dell'indice dell'ultimo stage spawnato
    private float stageOffset; // Si aggiorna ad ogni spawn con il valore del transfrom dello stage successivo
    private float triggerStageOffset; // Si aggiorna con il punto di detect per spawnare lo stage successivo
    [SerializeField] private int poolSize = 4;  //è il numero di stages che voglio tenere spawnati in contemporanea

    private MyInputSystem input = null;

    void Start()
    {
        // >>> QUALITY SETTINGS <<<
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 120;
        Screen.SetResolution(1480, 720,false);
        
        
        // >>> INIZIALIZZO LE VARIABILI <<<
        spawnPoint = playerGatto.transform.position.x; // Qui mi salvo lo spawn point del gatto
        
        stageOffset = 20; // Inizializzo lo spawn offset spostandolo dal primo stage permanente

        triggerStageOffset = -12; // Inizializzo il trigger offset

        // >>> INIZIALIZZO GLI ARRAY <<<
        stages = new GameObject[80];
        instantiatedEnemies = new GameObject[80];
        instantiatedPlatforms = new GameObject[80];

        // >>> CREO GLI STAGES INIZIALI <<<
        for (int i = 0; i < poolSize; i++)
        {
            stages[i] = Instantiate(prefabStage, new Vector3(stageOffset , 0, 0.5f), Quaternion.identity);
            stageOffset += stageWidth;
            triggerStageOffset += stageWidth;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if(playerGatto.transform.position.x > triggerStageOffset)
        {
            SpostaLoStage();
            CreaOggettiScena();
            CreaOggettiCibo();
            stageOffset += stageWidth;
            triggerStageOffset += stageWidth;
        }

        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = string.Format("FPS: {0:0.}", fps);

        print($"StageProgression: {stageProgression}");

        if (stageProgression > 40)
        {
            Time.timeScale = 0;
            print("Hai vinto");
        }
        
    }


    void SpostaLoStage()
    {
        
        // print($"Sto generando lo stage in {stageOffset}");
        // stages[stageCounter] = Instantiate(prefabStage, new Vector3(stageOffset , 0, 0.5f), Quaternion.identity);
        // stageCounter += 1;
        // if (stageCounter > 3)
        // {
        //     Destroy(stages[stageCounter-4]); 
        // }
        stageProgression++;
        stages[stageIndex].transform.position = new Vector3(stageOffset , 0, 0.5f);
        stageIndex += 1;
        if (stageIndex >= poolSize)
        {
            stageIndex = 0;
        }
        
    }


    void CreaOggettiScena()
    {
        // Creo piattaforme su cui saltare
        instantiatedPlatforms[instPlatformsCounter] = Instantiate(piattaforme[Random.Range(0, piattaforme.Length)], new Vector3(spawnPoint + stageOffset + Random.Range(0, stageWidth), Random.Range(2, 8), 0), Quaternion.identity);

        // Creo nemici
        instantiatedEnemies[instEnemiesCounter] = Instantiate(nemici[Random.Range(0, nemici.Length)], new Vector3(spawnPoint + stageOffset + Random.Range(0, stageWidth), 0, 0), Quaternion.identity);

    }

    void CreaOggettiCibo()
    {
        // Creo oggetti cibo
        GameObject cibo = Instantiate(oggettiCibo[Random.Range(0, piattaforme.Length)], new Vector3(spawnPoint + stageOffset + Random.Range(0, stageWidth), Random.Range(2, 8), 0), Quaternion.identity);
    }


    // Meccanica della fame del gatto
    // Mangia gli oggetti "palle di pelo"

    // Niente re-spawn, il gatto muore e si ricomincia da capo
    
    public void Pausa()
    {
        
        if (Time.timeScale == 0) 
        {
            Time.timeScale = 1;            
        }
        else 
        {
            Time.timeScale = 0;
            
            print("Pausa");
        }
    }
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