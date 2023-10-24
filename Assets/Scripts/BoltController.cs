using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    public float boltSpeed;
    private float startTime;
    public float destoryTime;
    public GameObject player;
    private Vector3 initPos;
    private Vector3 nowPos;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        initPos = transform.position;
        nowPos = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        nowPos += new Vector3(0, 0, boltSpeed);
        transform.position = nowPos;
        if (Time.time > startTime + destoryTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hitbox" || other.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
        
    }
    
}
