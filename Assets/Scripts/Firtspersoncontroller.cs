using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Firtspersoncontroller : MonoBehaviour
{

    float ver;
    float hor;
    public float speed;
    public float speedHor;
    public float range = 100f;
    public Camera Camera;

    public GameObject bulletPrefab;
    public GameObject impactEffect;
    public Transform cannon;
    public float frecuency;
    public bool stoped = false;


       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!stoped)
        {
            ver = Input.GetAxis("Vertical");
            hor = Input.GetAxis("Horizontal");

            transform.Translate(0, 0, ver * speed * Time.deltaTime);
            transform.Rotate(0, hor * speedHor * Time.deltaTime, 0);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Shooting();

            }
        }
    }

    void Shooting()
    {
        
      GameObject temp = Instantiate(bulletPrefab, cannon.position, Quaternion.identity);

      Rigidbody rb = temp.GetComponent<Rigidbody>();

        rb.AddForce(cannon.forward * frecuency, ForceMode.Impulse);

        
        RaycastHit hit;
        if (Physics.Raycast(cannon.transform.position, cannon.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Enemigo")
            {
                GameObject impactoGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            }
        }
    }
      
   }
