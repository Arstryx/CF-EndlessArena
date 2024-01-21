using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStar : MonoBehaviour
{
    public int hp = 100;
    public int damage = 25;
    public Healthbar healthbar;
    public GameObject player;
    public Rigidbody2D mRigidBody;

    public GameObject ammoBox;
    public GameObject hpBox;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerTriangle");
        mRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(hp<=0)
        {
            int i = UnityEngine.Random.Range(0, 7);
            if (i == 0)
            {
                Instantiate(ammoBox, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
            else if (i == 1)
            {
                Instantiate(hpBox, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
            Destroy(gameObject);
        }

        if (player != null)
         {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            float radianAngle = Mathf.Atan2(direction.y, direction.x);
            if (radianAngle < 0)
            {
                radianAngle = 6.28319f + radianAngle;
            }
            float angle = radianAngle * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            mRigidBody.MovePosition(transform.position + transform.up * 4 * Time.fixedDeltaTime);
         }
    }


    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Player Player = other.gameObject.GetComponent<Player>();
            Player.GetDamage(damage);
        }
    }


    public void GetDamage(int damage)
    {
        hp=hp-damage;
        Debug.Log(hp);
        if(healthbar!=null)
        {
            healthbar.UpdateHealthbar(hp / 100f);
        }
        
    }
}
