using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySuriken : MonoBehaviour
{

    [SerializeField] int damage = 10;
    [SerializeField] int moveSpeed = 10;
 
    private Vector2 randomDirection;

    void Start()
    {
        randomDirection = Random.insideUnitCircle.normalized;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Player Player = other.gameObject.GetComponent<Player>();
            Player.GetDamage(damage);
            Destroy(gameObject);
        }
        randomDirection = Random.insideUnitCircle.normalized;
    }

    void OnCollisionStay2D()
    {
        randomDirection = Random.insideUnitCircle.normalized;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    


   

    
}
