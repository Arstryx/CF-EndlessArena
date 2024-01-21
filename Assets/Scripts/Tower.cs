using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] int defense = 450;
    [SerializeField] int attack = 30;

    public Healthbar healthbar;
    public GameObject bulletPrefab;
    public Transform player;
    public float bulletSpeed = 15f;
    public float fireDelay = 1f;

    private float timeSinceLastFire = 0f;

    public GameObject ammoBox;
    public GameObject healthBox;


    public AudioSource source;
    public AudioClip deadSound;

    void Start()
    {
        player = GameObject.Find("PlayerTriangle").transform;
    }

    void FixedUpdate()
    {

        if(defense<=0)
        {
            int i = UnityEngine.Random.Range(0, 4);
            if (i == 0)
            {
                Instantiate(ammoBox, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
            else if (i == 1)
            {
                Instantiate(healthBox, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
            source.clip = deadSound;
            source.Play();
            Destroy(gameObject);
        }

        if (player != null)
        {
            timeSinceLastFire += Time.deltaTime*1f;

            if(timeSinceLastFire >= fireDelay)
            {
                Vector3 directionToPlayer = (player.position - transform.position).normalized;

                Vector3 spawnPosition = transform.position + directionToPlayer * 1f;

                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;


                GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.Euler(0f, 0f, angle));
                bullet.GetComponent<Bullet>().speed = bulletSpeed;
                timeSinceLastFire = 0f;
            }
        }
    }


    public void GetDamage(int damage)
    {
        defense=defense-damage;

        if(healthbar!=null)
        {
            healthbar.UpdateHealthbar(defense / 450f);
        }
        
    }

}
