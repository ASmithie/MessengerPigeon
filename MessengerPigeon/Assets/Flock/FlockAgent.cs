using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FlockAgent : MonoBehaviour
{

    BoxCollider agentCollider;
    public BoxCollider AgentCollider { get { return agentCollider; } }


    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<BoxCollider>();
    }

    public void Move(Vector3 velocity)
    {
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }
}
