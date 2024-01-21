using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] public int healthPoints = 100;
    [SerializeField] float shootSpeed = 10; 
    public GameObject bulletPrefab;
    public TextMeshProUGUI Healthbar, ammoBar;
    [SerializeField] public int ammunition = 300;
    public Healthbar healthBar;
    public Healthbar ammunitionBar;
    [SerializeField] float timeBetweenShots = 0.5f; 
    private float elapsedTime = 0f;
    public AudioSource sourceShooter;
    public AudioClip shotSound, oughSound;
    void FixedUpdate()
    {
        Healthbar.text = "HP: " + Convert.ToString(healthPoints);
        ammoBar.text  = "AMMO: " + Convert.ToString(ammunition);
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
            RotatePlayerToMouse();
            MovePlayer();


        elapsedTime += Time.deltaTime;
        if (Input.GetButton("Fire1") && elapsedTime >= timeBetweenShots && ammunition > 0)
        {
            Shoot();
            elapsedTime = 0f;
        }

            
            
            
    
    }


    void RotatePlayerToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 mouseDirection = mousePosition - transform.position;
        mouseDirection.z = 0f;
        transform.up = mouseDirection.normalized;
    }


    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void Shoot()
    {
        ammunition--;
        ammunitionBar.UpdateHealthbar(ammunition / 300f);
        Vector3 localOffset = transform.rotation * new Vector3(0f, 0.9f, 0f);
        Vector3 spawnPosition = transform.position + localOffset;
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, transform.rotation);
        bullet.GetComponent<Bullet>().speed = shootSpeed;
        sourceShooter.clip = shotSound;
        sourceShooter.Play();
    }




    public void GetDamage(int damage)
    {
        sourceShooter.clip = oughSound;
        sourceShooter.Play();
        healthPoints = healthPoints - damage;
        healthBar.UpdateHealthbar(healthPoints / 100f);
    }
 }

