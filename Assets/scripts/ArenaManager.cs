using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fce;
using System.Linq;
using TMPro;

public class ArenaManager : MonoBehaviour
{
    public int NumOfWave;
    public GameObject Batery;
    public GameObject Mecha;
    public GameObject Pilot;
    public GameObject Shop;

    public GameObject Canvas;
    public GameObject EnemySpawner;
    public float WaveTotalTime = 15f; // Total time for the timer in seconds
    public float betweenWaveTime = 20f;

    
    
    private TextManager textManager;
    private EnemySpawnerManager enemySpawnerManager;
    public GameObject[] Enemy = null;
    private bool IsWave=false;
    private float remainingTime; // Remaining time for the timer


    private void Awake() {
        textManager = Canvas.GetComponent<TextManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerManager = EnemySpawner.GetComponent<EnemySpawnerManager>();
        WaveStart();
    }
    private void FixedUpdate() {
        if(Mecha!=null || Pilot != null){
            remainingTime -= Time.deltaTime;
            textManager.UpdateTime(remainingTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsWave){
            if (remainingTime <= 0f && Enemy.All(enemy => enemy == null))
            {
                WaveEnd();
            }
        }else{
            if(remainingTime<=0f){
                WaveStart();
            }
        }
        
        
    }

    void WaveStart()
    {
        Shop.SetActive(false);
        NumOfWave++;
        textManager.UpdateWave(NumOfWave);
        remainingTime = WaveTotalTime;
        IsWave=true;
        enemySpawnerManager.spawninig(NumOfWave);
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }
    void WaveEnd()
    {
        GameObject spawnedBatery = Instantiate(Batery, Mecha.transform.position + Fce.ringSpawn(1,5f,0.2f), transform.rotation);
        remainingTime=betweenWaveTime;
        WaveTotalTime*=1.5f;
        Shop.SetActive(true);
        BetweenWave();
    }
    void BetweenWave()
    {
        IsWave=false;
    }

    public int getWaves(){
        return NumOfWave;
    }
}
