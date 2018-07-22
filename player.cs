using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerController))]
[RequireComponent(typeof(GunController))]
public class player : LivingEntity {

    public float moveSpeed = 5;
    Camera ViewCamera;
    PlayerController controller;
    GunController gunController;
    public bool vrMode;

    protected override void Start () {

        base.Start();
        controller = GetComponent<PlayerController> ();
        ViewCamera = Camera.main;
        gunController = GetComponent<GunController>();
	}
	
	void Update () {
        //Move Input
        
        controller.Move(moveSpeed, vrMode);

        if(vrMode){
            if(Input.GetKey(KeyCode.JoystickButton4)){
                gunController.Shoot();
            }

        }
        else {
             //WeaponInput
            if (Input.GetMouseButton(0)) {
                gunController.Shoot();
            }
        }
       


     
	}
}
