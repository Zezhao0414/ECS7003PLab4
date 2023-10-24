using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AsteroidGeneration : MonoBehaviour
{
    private float timeRecord;
    public GameObject[] asteroids;
    private GameObject[] genPos;
    public float timeInterval;
    // Start is called before the first frame update
    void Start()
    {
        timeRecord = Time.time;
        genPos = GameObject.FindGameObjectsWithTag("Generation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(Time.time > timeRecord + timeInterval)
        {
            //int x = Random.Range(0, 3);
            for(int i=0; i<genPos.Length; i++)
            {
                int x = Random.Range(0, 3);
                if (i != x)
                {
                    int a = Random.Range(0, 3);
                    Instantiate(asteroids[a], genPos[i].transform);
                }
            }
            timeRecord = Time.time;
        }
    }
}
