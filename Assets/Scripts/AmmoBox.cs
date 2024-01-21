using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
 
    private int ammos = 300;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            Player Player = other.gameObject.GetComponent<Player>();
            Player.ammunition=ammos;
            Destroy(gameObject);
        }
        
    }
}
