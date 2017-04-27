using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour {


    
    public static bool hit2 = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Battle_map")
            Destroy(gameObject);

        if (collision.gameObject.name == "tank_1")
        {
            ScoreDisplay.score2 += 1;
            hit2 = true;
            Destroy(gameObject);
        }

    }
}
