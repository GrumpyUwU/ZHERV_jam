using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControler : MonoBehaviour
{
    private EnemyControler enemyControler;
    public float timeToDespawn = 1.5f;

    private void FixedUpdate() {
        timeToDespawn -= Time.deltaTime;
        if(timeToDespawn<=0){
            Destroy(this.gameObject);
        }
    }   
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag or layer
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Call your function or execute your code when hit
            OnHit();
            GameObject HitObject = collision.gameObject;
            enemyControler = HitObject.GetComponent<EnemyControler>();
            enemyControler.hit(5);
        }
    }

    void OnHit()
    {
        // Your custom logic when the object is hit
        Destroy(this.gameObject);
    }
}
