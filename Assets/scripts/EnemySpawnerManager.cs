using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fce;
using System;


public class EnemySpawnerManager : MonoBehaviour
{
    public GameObject[] Enemy;
    

    
    /*private void Start() {
        spawninig(5);
    }*/

    public void spawninig(int Dif){
        int val = (int)(150 * Math.Pow(1.75, Dif));
        //spawn slime
        for (int i = val; i > 0; i-=50)
        {
            GameObject spawnedEnemy = Instantiate(Enemy[0], Fce.ringSpawn(1,20f,0.2f), transform.rotation);
        }
    } 
}
