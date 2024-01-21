using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 15f;
    public int damage = 20;
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "Player")
            {
                Player Player = other.gameObject.GetComponent<Player>();
                Player.GetDamage(damage);
            }
            if (other.gameObject.tag == "Tower")
            {
                Tower Tower = other.gameObject.GetComponent<Tower>();
                Tower.GetDamage(damage);
            }
            if (other.gameObject.tag == "ZombieStar")
            {
                ZombieStar Zombie = other.gameObject.GetComponent<ZombieStar>();
                Zombie.GetDamage(damage);
            }
            Destroy(gameObject);
    }


}
