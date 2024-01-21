using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class Spawner : MonoBehaviour
{

    /*
        Spawn area is splitted into 4 different parts, 
        so player will always know where he 
        should expect enemies to come from.
    */
    public struct arenaPart
    {   
        public string name;
        public float minX;
        public float minY;
        public float maxX;
        public float maxY;


        public arenaPart(string text, int x, int y, int width, int height)
        {
            name = text;
            minX = x;
            minY = y;
            maxX = width;
            maxY = height;
        }
    }

    private float difficulty = 1;

    // How quickly difficulty changes
    public float speedChangeDifficulty;

    // All possible enemies
    public GameObject suriken, tower, zombie;
    // Start is called before the first frame update

    private float minX;
    private float minY;
    private float maxX;
    private float maxY;



    // Setting up 4 spawn areas and adding them to array.
    public arenaPart north = new arenaPart("North", -10, 0, 10, 10);
    public arenaPart south = new arenaPart("South", -10, -10, 10, 0);
    public arenaPart east = new arenaPart("East", 0, -10, 10, 10);
    public arenaPart west = new arenaPart("West", -10, -10, 0, 10);
    
    public arenaPart[] arenaParts = new arenaPart[4];
    
    public TextMeshProUGUI notificationText;

    public float spawnDelay = 3f;


    void Start()
    {
        arenaParts[0] = north;
        arenaParts[1] = south;
        arenaParts[2] = west;
        arenaParts[3] = east;

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {


        // Spawning each wave after the delay
        while (true)
        {
            int areaChose = Random.Range(0,4);
            minX = arenaParts[areaChose].minX;
            minY = arenaParts[areaChose].minY;
            maxX = arenaParts[areaChose].maxX;
            maxY = arenaParts[areaChose].maxY;

            notificationText.text = "New wave in 3 seconds from " + arenaParts[areaChose].name;
            yield return new WaitForSeconds(3);
            notificationText.text = "Wave is here!";
            for(int i = 0; i < difficulty; i++)
            {
                Vector3 spawnSuriken = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
                Instantiate(suriken, spawnSuriken, Quaternion.identity);
            }


            for(int i = 0; i <  difficulty/2f; i++)
            {
                Vector3 spawnTower = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
                Instantiate(tower, spawnTower, Quaternion.identity);
            }


            for(int i = 0; i <  difficulty; i++)
            {
                Vector3 spawnZombie = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
                Instantiate(zombie, spawnZombie, Quaternion.identity);
            }

            
            
            difficulty = difficulty + speedChangeDifficulty;
            
            yield return new WaitForSeconds(spawnDelay-3);

            spawnDelay+=speedChangeDifficulty*3;
        }
    }



}
