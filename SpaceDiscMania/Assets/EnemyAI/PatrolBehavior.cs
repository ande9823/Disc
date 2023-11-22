using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class PatrolBehavior : StateMachineBehaviour
{
    float timer;
    public List<Transform> wayPoints = new List<Transform>();
    //Transform randomWaypoint = null; // a random waypoint to patrol to.

    NavMeshAgent agent;

    Transform player;
    float chaseRange = 15;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        /*
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPoints").transform;
        foreach (Transform t in wayPointsObject)
            wayPoints.Add(t);*/
        
        agent = animator.GetComponent<NavMeshAgent>();
        /*agent.SetDestination(wayPoints[0].position);*/

        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Makes a random waypoint around the agent and adds it to the waypoint list.
        GameObject waypoint = GameObject.Find("Waypoint");
        waypoint.GetComponent<RandomWaypoint>().UpdateWaypoint();
        wayPoints.Insert(0, waypoint.transform);
        agent.SetDestination(wayPoints[0].position);
        /*
        randomWaypoint.position = new Vector3(agent.gameObject.transform.position.x - UnityEngine.Random.Range(0, 5), 0 , agent.gameObject.transform.position.z - UnityEngine.Random.Range(0, 5));
        wayPoints.Insert(0, randomWaypoint);
        agent.SetDestination(wayPoints[0].position);
        */
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);*/

        timer += Time.deltaTime;
        if (timer > 10)
            animator.SetBool("isPatrolling", false);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseRange)
            animator.SetBool("isChasing", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
