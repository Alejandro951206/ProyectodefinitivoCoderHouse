using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firtspersoncontroller : MonoBehaviour
{

    float ver;
    float hor;
    public float speed;
    public float speedHor;

    public GameObject bulletPrefab;
    public Transform cannon;
    public float frecuency;

    public int score;
    public Text TXTscore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, ver * speed * Time.deltaTime);
        transform.Rotate(0,hor * speedHor * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Shooting();

        }


    }

    void Shooting()
    {
        
      GameObject temp = Instantiate(bulletPrefab, cannon.position, Quaternion.identity);

      Rigidbody rb = temp.GetComponent<Rigidbody>();

        rb.AddForce(cannon.forward * frecuency, ForceMode.Impulse);
    }
}
