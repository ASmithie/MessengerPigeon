using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;

    public float step = 10;

    public float nextActionTime = 0f;
    public float period = 1f;

    public float maxSeeingDistance = 100f;

    public Vector3 heading;

    public bool roaming = false;
    public Vector3 roamNode;


    // FixedUpdate is called once per fixed framerate frame
    void FixedUpdate()
    {
        //Shoots raycast to get distance between player and enemy
        RaycastHit hitDistance;
        Physics.Raycast(transform.position, player.transform.position - transform.position, out hitDistance);
        Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green, 1f);

        //checks if player is with a set distance of the enemy, if not the enemy wonders to random points patrolling
        if (hitDistance.distance < maxSeeingDistance)
        {
            //Every period seconds the position the enemy moves towards is updated to just in front of the player. This gives the impression of a straight dash rather than a standard follow
            if (Time.time > nextActionTime)
            {
                nextActionTime = Time.time + period;


                RaycastHit hitPosition;
                //Can the enemy see the player
                if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hitPosition))
                {
                    //Update the position the enemy moves toward
                    heading = player.transform.GetChild(1).gameObject.transform.position;

                    Debug.DrawRay(transform.position, heading - transform.position, Color.red, 10);

                }
            }


            //Dash towards player
            transform.position = Vector3.MoveTowards(transform.position, heading, step);
        } else
        {
            if (roaming)
            {
                transform.position = Vector3.MoveTowards(transform.position, roamNode, 2f);
                if (transform.position == roamNode)
                {
                    roaming = false;
                }
            } else
            {
                roamNode = new Vector3(Random.Range(-200f, 200f), Random.Range(0f, 200f), Random.Range(-200f, 200f));
                roaming = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Caught");
            Debug.Log(heading);
            SceneManager.LoadScene("LoseScreen");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxSeeingDistance);
    }
}
