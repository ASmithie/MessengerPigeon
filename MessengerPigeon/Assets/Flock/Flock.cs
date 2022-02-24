using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();

    public FlockBehaviour behaviour;

    [Range(10, 500)]
    public int startingSize = 200;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(0f, 10f)]
    public float neighbourRadius = 1.5f;
    [Range(0f,1f)]
    public float avoidRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidRadius;
    public float SquareAvoidRadius {  get { return squareAvoidRadius; } }


    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidRadius = squareNeighbourRadius * avoidRadiusMultiplier * avoidRadiusMultiplier;

        for(int i = 0; i < startingSize; i++)
        {
            FlockAgent newAgent = Instantiate(agentPrefab, (Random.insideUnitSphere * startingSize * AgentDensity) + transform.position, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)));
            newAgent.name = "Agent" + i;
            agents.Add(newAgent);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            /*agent.GetComponentInChildren<Renderer>().material.SetColor("_Color",Color.Lerp(Color.white, Color.red, context.Count / 6f));*/


            Vector3 move = behaviour.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
            Debug.DrawRay(agent.transform.position, agent.transform.forward);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighbourRadius);
        foreach(Collider c in contextColliders)
        {
            if(c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }
}
