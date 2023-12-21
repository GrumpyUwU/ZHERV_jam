using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace fce{
    public class Fce : MonoBehaviour
    {
        public static Vector3 ringSpawn(int numberOfObj, float radius, float height){
            float angle = Random.Range(0f, 1f) * (360f/numberOfObj);
            float radians = Mathf.Deg2Rad * angle;
            float x = Mathf.Cos(radians) * radius;
            float z = Mathf.Sin(radians) * radius;
            return new Vector3(x, height, z);
        }

        public static GameObject ClosestTarget(GameObject player,float range){
            float distance = 0f;
            GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject Target = null;
            for (int i = 0; i < Enemy.Length; i++)
            {
                distance = Vector3.Distance(player.transform.position, Enemy[i].transform.position);
                if(distance<=range){
                    range=distance;
                    Target=Enemy[i];
                }
            }
            return Target;
        }

        public static void shoot(GameObject bulletPrefab, Transform character, Transform enemy){
            GameObject bullet = Instantiate(bulletPrefab, character.position, character.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            Vector3 shootDirection = (enemy.position - character.position).normalized;
            rb.AddForce(shootDirection * 10, ForceMode.Impulse);
        }
        
    }
}