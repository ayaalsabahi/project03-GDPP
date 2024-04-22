using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class PoliceDuck : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent agent;
    bool isFollowing = false;
    public float followSpeed = 50f;



    [Header("For not fleeing")]
    public float roamRadius = 10f;
    public float roamTimer = 1000f; //every how many seconds change positions
    private float timer; //temporary variable
    private Vector3 randomDestination;

    // Start is called before the first frame update
    private void Start()
    {
        //gameObject.SetActive(false); //at the start we deactivate the duck
        
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false; 
    }

    //this is where the duck will be following the player, it will do so using navmesh
    public void FollowDuck()
    {
        Debug.Log("hey police active");
        isFollowing = true;
        //gameObject.SetActive(true);
        agent.enabled = true;
        agent.speed = followSpeed; 
    }

    private void Update()
    {
        if (isFollowing && !GameManager.Instance.isHidden) //only follow if not hiding
        {
            agent.SetDestination(player.position);
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0f) //find new position if not fleeing
            {
                SetRandomDestination();
                timer = roamTimer;

            }
        }
        
    }

    public void DontFollowDuck()
    {
        isFollowing = false; //basically stop where you are / roam around -> something to change later on 
    }

    private void SetRandomDestination()
    {
        randomDestination = RandomSphere(transform.position, roamRadius, -1);
        agent.SetDestination(randomDestination);
    }

    private Vector3 RandomSphere(Vector3 origin, float dist, int layers)
    {
        Vector3 dirRand = Random.insideUnitSphere * dist;
        dirRand += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(dirRand, out navHit, dist, layers);
        return navHit.position;
    }
}
