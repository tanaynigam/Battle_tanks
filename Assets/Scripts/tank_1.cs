using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_1 : MonoBehaviour {

    [SerializeField]
    Transform tank1;

    [SerializeField]
    Transform scope;

    public float moveSpeed;
    private float input1;
    private float input2;
    private Vector3 dir;
    public Rigidbody projectile;


    private Vector3 spawnPoint1 = new Vector3(16f, 0.5f, -3f);
    private Vector3 spawnPoint2 = new Vector3(-16f, 0.5f, -3f);
    private Vector3 spawnPoint3 = new Vector3(16f, 0.5f, 3f);
    private Vector3 spawnPoint4 = new Vector3(-16f, 0.5f, 3f);
    private Vector3 spawnPoint5 = new Vector3(16f, 0.5f, -16f);
    private Vector3 spawnPoint6 = new Vector3(-16f, 0.5f, -16f);
    private Vector3 spawnPoint7 = new Vector3(16f, 0.5f, 16f);
    private Vector3 spawnPoint8 = new Vector3(-16f, 0.5f, 16f);
    private Vector3 spawnPoint9 = new Vector3(0f, 0.5f, -10f);
    private Vector3 spawnPoint0 = new Vector3(0f, 0.5f, 10f);

    private Vector3 newSpawnPoint;
    private int choice;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        AudioSource[] source = GetComponents<AudioSource>();

        tank_movement();
        tank_shoot();
        if(Bullet2.hit2 == true)
        {
            source[1].Play();
            Respawn();
        }

    }

    public void tank_movement()
    {

        input1 = Input.GetAxis("Horizontal2");
        input2 = Input.GetAxis("Vertical2");

        if (input1 != 0 || input2 != 0)
        {
            dir.x = input1;
            dir.z = input2;
            tank1.rotation = Quaternion.LookRotation(dir);
            tank1.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else
            tank1.Translate(0, 0, 0);

    }

    public void tank_shoot()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            {
                Rigidbody clone;
                clone = Instantiate(projectile, scope.position, scope.rotation) as Rigidbody;
                
                clone.AddForce(tank1.forward * 50f, ForceMode.Impulse);
                AudioSource[] source = GetComponents<AudioSource>();
                source[0].Play();
        }
    }

    public void Respawn()
    {

        choice = Random.Range(1, 11);
        switch (choice)
        {
            case 1:
                newSpawnPoint = spawnPoint1;
                break;
            case 2:
                newSpawnPoint = spawnPoint2;
                break;
            case 3:
                newSpawnPoint = spawnPoint3;
                break;
            case 4:
                newSpawnPoint = spawnPoint4;
                break;
            case 5:
                newSpawnPoint = spawnPoint5;
                break;
            case 6:
                newSpawnPoint = spawnPoint6;
                break;
            case 7:
                newSpawnPoint = spawnPoint7;
                break;
            case 8:
                newSpawnPoint = spawnPoint8;
                break;
            case 9:
                newSpawnPoint = spawnPoint9;
                break;
            case 10:
                newSpawnPoint = spawnPoint0;
                break;
        }

        tank1.position = newSpawnPoint;
        Bullet2.hit2 = false;
    }



  

}
