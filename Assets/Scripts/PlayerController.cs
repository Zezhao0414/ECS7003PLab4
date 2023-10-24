using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Vector2 moveValue;
    private Vector3 speed;
    public float rotationFactor;
    public GameObject MainCamera;
    public GameObject BoltPrefab;
    public GameObject firePosition;
    private Vector3 mainCameraPos;
    public GameObject AsteroidGen;
    private float timeRecord;
    public float fireInterval;
    public GameObject winText;
    public GameObject loseText;
    public GameObject hitbox;
    public GameObject asteroidHitbox;
    //public float x;
    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector3(0, 0, 0.03f);
        timeRecord = Time.time;
    }
    private void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    private void OnFire()
    {
        if(Time.time > timeRecord + fireInterval)
        {
            Transform firePoint = firePosition.transform;
            Instantiate(BoltPrefab, firePoint);
            timeRecord = Time.time;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        mainCameraPos = MainCamera.GetComponent<Transform>().position;
    }
    private void FixedUpdate()
    {
        if (transform.position.x > 3)
        {
            transform.position = new Vector3(3, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -3)
        {
            transform.position = new Vector3(-3, transform.position.y, transform.position.z);
        }
        if(transform.position.z < MainCamera.GetComponent<Transform>().position.z - 4.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, mainCameraPos.z - 4.5f);
        }
        if (transform.position.z > MainCamera.GetComponent<Transform>().position.z + 4.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, mainCameraPos.z + 4.5f);
        }

        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        transform.position += (0.1f * movement + speed);
        transform.rotation = Quaternion.Euler(0,0, - Mathf.Sin(moveValue.x) * rotationFactor);
        MainCamera.GetComponent<Transform>().position += speed;
        AsteroidGen.GetComponent<Transform>().position += speed;
        hitbox.GetComponent<Transform>().position += speed;
        asteroidHitbox.GetComponent<Transform>().position += speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Winbox")
        {
            winText.SetActive(true);
            //Debug.Log("Win!");
            Time.timeScale = 0;
        }
        else if(other.tag == "Asteroid")
        {
            Destroy(gameObject);
            loseText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
