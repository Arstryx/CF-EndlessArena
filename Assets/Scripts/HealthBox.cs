using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            Player Player = other.gameObject.GetComponent<Player>();
            Player.healthPoints=100;
            Player.GetDamage(0);
            Destroy(gameObject);
        }
        
    }
}
