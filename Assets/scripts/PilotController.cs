using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fce;


public class PilotController : MonoBehaviour
{
    
    public float speed = 3f;
    public GameObject bulletPrefab;
    public float HP = 20f;
    public float Money = 0;


    public GameObject Enemy = null;
    private float nextFireTime = 0;
    public float cooldownTime = 1;

    public void MovePilot(Vector3 direction)
    {
        // Translate the player in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public bool PickupBatery(bool BateryCaried){
        GameObject[] Batery = GameObject.FindGameObjectsWithTag("Batery");
        for (int i = 0; i < Batery.Length; i++){
                float distance = Vector3.Distance(transform.position, Batery[i].transform.position);
                if(distance<=0.6f && !BateryCaried){
                    Destroy(Batery[i]);
                    return true;
                }
        }
        return BateryCaried;
    }

    public void PilotAutoShoot()
    {
        if(Enemy!=null){
            if (Time.time >= nextFireTime)
            {
                Fce.shoot(bulletPrefab,this.transform,Enemy.transform);
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    public void hit(float DMG){
        HP-=DMG;
        if(HP<0){
            HP=0;
        }
    }

}
