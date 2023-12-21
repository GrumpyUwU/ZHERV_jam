using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fce;

public class PlayerHandler : MonoBehaviour
{
    public GameObject Mecha;
    public GameObject Pilot;
    public GameObject Cam;
    public GameObject UIcanvas;
    public GameObject GameOverCanvas;
    public GameObject Arena;


    private GameObject ObjectToFollow;
    private float horizontal;
    private float vertical;
    private int MechaCam=8;
    private int PilotCam=5;
    public bool BateryCaried = false; 
    Vector3 movement;

    private bool isPiloting=true;


    private MechaController mechaController;
    private ArenaManager arenaManager;
    private PilotController pilotController;
    private FollowPlayer followPlayer;
    private TextManager textManager;
    private GameOverText textGameOver;

    // Start is called before the first frame update
    private void Awake() {
        textManager = UIcanvas.GetComponent<TextManager>();
        textGameOver = GameOverCanvas.GetComponent<GameOverText>();
        arenaManager = Arena.GetComponent<ArenaManager>();

        mechaController = Mecha.GetComponent<MechaController>();
        pilotController = Pilot.GetComponent<PilotController>();
        followPlayer = Cam.GetComponent<FollowPlayer>();
        
        
        Pilot.SetActive(!isPiloting);
        ObjectToFollow=Mecha;
        followPlayer.SwitchObject(ObjectToFollow,MechaCam);
    }

    private void FixedUpdate() {
        if(Pilot == null || Mecha == null){

            return;
        }
        movement = new Vector3(horizontal, 0f, vertical).normalized;
        if(movement!=new Vector3(0,0,0)){
            if(isPiloting){
                mechaController.MoveMecha(movement);

            }else{
                pilotController.MovePilot(movement);
            }
        }
        mechaController.MechaAutoShoot();
        if(!isPiloting){
            pilotController.PilotAutoShoot();
        }
        mechaController.Enemy =  Fce.ClosestTarget(Mecha,8f);
        pilotController.Enemy =  Fce.ClosestTarget(Pilot,5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(mechaController.Durability<=0&&isPiloting){
                TogglePiloting();
                Debug.Log("this");
            }
        if (Input.GetKeyDown(KeyCode.E)){
            if(isPiloting){
                TogglePiloting();
            }else{
                if(Vector3.Distance(Pilot.transform.position, Mecha.transform.position)<=1f&&mechaController.Durability>0){
                    TogglePiloting();
                    if(BateryCaried){
                        mechaController.BateryInsert();
                        BateryCaried=false;
                    }
                }else{
                    BateryCaried = pilotController.PickupBatery(BateryCaried);
                }
            }
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        textManager.UpdateEnergy(mechaController.energy);
        textManager.UpdateDurability(mechaController.Durability);
        textManager.UpdateHP(pilotController.HP);


        if(pilotController.HP<=0){
            Destroy(Pilot);
            Destroy(Mecha);
            GameOverCanvas.SetActive(true);
            textGameOver.Waves(arenaManager.getWaves()-1);
            UIcanvas.SetActive(false);

        }


    }

    void TogglePiloting()
    {
        isPiloting = !isPiloting;
        Pilot.transform.position =Mecha.transform.position;
        ObjectToFollow=isPiloting?Mecha:Pilot;
        Pilot.SetActive(!isPiloting);
        followPlayer.SwitchObject(ObjectToFollow,(ObjectToFollow==Mecha)?MechaCam:PilotCam);
    }

    public void money(float val){
        pilotController.Money += val;
    }

    
}
