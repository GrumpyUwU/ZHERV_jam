using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fce;



public class EnemyControler : MonoBehaviour
{
    
    public enum EnemyType
    {
        range,
        mele
    }
    public float HP = 15;
    public float speed = 5;
    public float cooldownTime = 2;
    private float nextTime = 0;
    public EnemyType chosenType = EnemyType.mele;

    public GameObject Mecha=null;
    public GameObject Pilot=null;
    public GameObject TargetToHit=null;
    public GameObject Drop=null;

    private GameObject HitObject=null;
    

    private MechaController mechaController;
    private PilotController pilotController;
    private bool bite = false;

    private void Start() {
        FoundTarget();  
    }

    private void FixedUpdate() {
        Mecha = GameObject.FindGameObjectWithTag("Mecha");
        Pilot = GameObject.FindGameObjectWithTag("Pilot");
        TargetToHit=(Pilot!=null)?Pilot:Mecha;
        folowTarget(TargetToHit);
        if(bite && TargetToHit!=null){
            if (Time.time >= nextTime)
            {
                bite=true;
                nextTime = Time.time + cooldownTime;
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag or layer
        if (collision.gameObject.CompareTag("Mecha")||collision.gameObject.CompareTag("Pilot"))
        {
            HitObject = collision.gameObject;
            biteTarget(HitObject);
            bite = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if the colliding object has a specific tag or layer
        if (collision.gameObject.CompareTag("Mecha")||collision.gameObject.CompareTag("Pilot"))
        {
            bite = false;
        }
    }



    public void FoundTarget(){
        Mecha = GameObject.FindGameObjectWithTag("Mecha");
        Pilot = GameObject.FindGameObjectWithTag("Pilot");
    }

    public void hit(float DMG){
        HP -= DMG;
        if(HP<=0){
            bite=false;
            int randomInt = Random.Range(1, 3);
            for (int i = 0; i < randomInt; i++)
            {
                GameObject Cristal = Instantiate(Drop, transform.position+Fce.ringSpawn(1,0.1f,0.3f), transform.rotation);
            }
            Destroy(this.gameObject);

        }
    }

    private void folowTarget(GameObject target){
        if(target!=null){
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }    
    }

    public void biteTarget(GameObject target){
        if(target == Mecha){
            mechaController = target.GetComponent<MechaController>();
            mechaController.hit(5);
        }else if(target == Pilot){
            pilotController = target.GetComponent<PilotController>();
            pilotController.hit(5);
        }

    }


}
