using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private AudioSource _audioS;

    // Start is called before the first frame update
    void Start()
    {
        _audioS = GetComponent<AudioSource>();
        _audioS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);
    }
        
}

