using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fce;

public class MechaController : MonoBehaviour
{
    public float speed = 2.5f;
    public float EnergyCp = 0.5f;
    public float energy = 100f;
    public float Durability = 100f;
    private float nextFireTime = 0;
    public float cooldownTime = 1;
    public GameObject bulletPrefab;
    public GameObject Enemy = null;
 


    private void FixedUpdate() {
        if(energy>Durability){
            energy=Durability;
        }
    }
    public void MoveMecha(Vector3 direction)
    {
        // Translate the player in the specified direction
        if(energy>0){
            transform.Translate(direction * speed * Time.deltaTime);
            energy -=EnergyCp;
        }
    }

    public void BateryInsert()
    {
        energy = Durability; 
    }

    public void MechaAutoShoot()
    {
        if(Enemy!=null && energy>0){
            if (Time.time >= nextFireTime)
            {
                Fce.shoot(bulletPrefab,this.transform,Enemy.transform);
                nextFireTime = Time.time + cooldownTime;
                energy-=1;
            }
        }
    }

    public void hit(float DMG){
        Durability-=DMG;
        if(Durability<0){
            Durability=0;
        }
    }
}
