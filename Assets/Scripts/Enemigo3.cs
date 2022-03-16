using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State
{
    MoveEnemy,
    StareEnemy,
    
}
public class Enemigo3 : MonoBehaviour
{

    public State changeState;

    public Transform playerPos;

    public float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        playerdistance();
        distance();

        switch (changeState)
        {
            case State.MoveEnemy:
                EnemyMove();
                break;
            case State.StareEnemy:
                LookPlayer();
                break;
            default:
                break;
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

    void distance()
    {

        float dist = Vector3.Distance(playerPos.position, transform.position);

        if (dist <= 2)
        {

            speed = 0;

        }
        else
        {
            speed = 2f;
        }

    }

}
