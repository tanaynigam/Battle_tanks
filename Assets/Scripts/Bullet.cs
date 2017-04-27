using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public static bool hit1 = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Battle_map")
            Destroy(gameObject);

        if (collision.gameObject.name == "tank_2")
        {
            ScoreDisplay.score1 += 1;
            hit1 = true;
            Destroy(gameObject);
            
        }
        
    }
}
