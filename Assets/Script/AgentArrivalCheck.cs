using UnityEngine;
using UnityEngine.AI;
public class AgentArrivalCheck : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform destinationPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destinationPos.position);
        if (HasReachedDestination(agent))
        {
            Debug.Log("I've Reached my Destination");
        }
    }

    bool HasReachedDestination(NavMeshAgent _agent)
    {
        if (_agent.remainingDistance > _agent.stoppingDistance) // distance
            return false;
        if(_agent.pathPending) //if AI have a path pending
            return false;
        if(_agent.hasPath && _agent.velocity.sqrMagnitude > 0)
            return false;

        return true;
    }
}
