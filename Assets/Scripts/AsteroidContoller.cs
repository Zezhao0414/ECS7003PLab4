using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidContoller : MonoBehaviour
{
    private float anglex;
    private float angley;
    private float anglez;
    private float forcex;
    private float forcez;

    // Start is called before the first frame update
    void Start()
    {
        anglex = Random.Range(1, 3);
        angley = Random.Range(1, 3);
        anglez = Random.Range(1, 3);
        forcex = Random.Range(-30, 30);
        forcez = Random.Range(-150, -120);
        GetComponent<Rigidbody>().AddForce(forcex, 0, forcez);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        transform.Rotate(anglex, angley, anglez);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bolt" || collision.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "AsteroidHitbox")
        {
            Destroy(gameObject);
        }
    }
}
