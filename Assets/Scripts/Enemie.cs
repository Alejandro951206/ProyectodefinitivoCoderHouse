using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DistanciadelJugador
{
    near,
    far,
    disable,
}
public class Enemie : MonoBehaviour
{

    int enemieLife = 50;

    public Transform playerPos;
    float speed;
    Animator anim;
    float deadTime;
    bool diying;
    private AudioSource _dead;
    public DistanciadelJugador enemidistance;
    bool stopIt = false;
    


    // Start is called before the first frame update
    void Start()
    {
        //Obtener la animaci�n y mirar al jugador
        anim = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        enemidistance = DistanciadelJugador.far;

       

        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed();

        if (diying)
        {
            deadTime += Time.deltaTime;
            
        }
        else
        {
            if (!stopIt)
            {

                EnemyMove();
                playerdistance();
                LookPlayer();
                
            }           

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

    // Impacto de balas y muerte del enemigo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            enemieLife -= 25;

            if (enemieLife <= 0)
            {

                
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                _dead = GetComponent<AudioSource>();
                _dead.Play();
                GameManager.gM.enemieList.Remove(gameObject);
                anim.SetTrigger("Dead");
               

                diying = true;

             GameManager.gM.score++;  

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
            case DistanciadelJugador.disable:
                stopIt = true;
                break;
        }
    }

   
    
}
