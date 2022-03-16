using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DistanciadelJugador
{
    near,
    far,
}
public class Enemie : MonoBehaviour
{

    int enemieLife = 50;

    public Transform playerPos;
    float speed;
    Animator anim;
    float deadTime;
    bool diying;
    DistanciadelJugador enemidistance;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        enemidistance = DistanciadelJugador.far;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (diying)
        {
            deadTime += Time.deltaTime;
        }
        else
        {
            EnemyMove();
            playerdistance();
            LookPlayer();
            ChangeSpeed();
        }

        if (deadTime > 2)
        {
            GameManager.gM.currentEnemies--;
            Destroy(gameObject);
           

        }

        float dist = Vector3.Distance(playerPos.position, transform.position);

        if (dist <= 10)
        {

            enemidistance = DistanciadelJugador.near;

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            enemieLife -= 25;

            if (enemieLife <= 0)
            {
               
              anim.SetTrigger("Dead");             
              diying = true;

                
            }
        }
    }

    void LookPlayer()
    {

        Quaternion rot = Quaternion.LookRotation(playerPos.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);

    }

    void playerdistance()
    {
        float dis = Vector3.Distance(playerPos.position, transform.position);


    }

    void EnemyMove()
    {

        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

    }

    void ChangeSpeed()
    {

        switch (enemidistance)
        {
            case DistanciadelJugador.near:
                speed = 2;
                break;
            case DistanciadelJugador.far:
                speed = 7;
                break;
            default:
                break;
        }
    }

}
