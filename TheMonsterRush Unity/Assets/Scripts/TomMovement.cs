using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TomMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<Transform> targets;
    public int targetIndex;
    public float timer, stayingTimer, patrolingSpeed;
    [SerializeField] GameObject lookAt;
    // Start is called before the first frame update
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patroling();
    }
    public void Patroling()
    {
        agent.SetDestination(targets[targetIndex].position);
        agent.speed = patrolingSpeed;
        float distance = Vector3.Distance(transform.position, targets[targetIndex].position);
        if (distance <= 1) // checks if distance to a point less than one, than destination set is true so it would look for a new destination
        {
            agent.speed = 0;
            timer += Time.deltaTime;

            float speed = 2 * Time.deltaTime;
            Vector3 calculatedDirection = lookAt.transform.position - transform.position;   
            Vector3 appliedDirection = Vector3.RotateTowards(transform.forward, calculatedDirection, speed, 0f);   

            transform.rotation = Quaternion.LookRotation(appliedDirection);   

            Debug.Log(transform.rotation.y);

            if (timer >= stayingTimer)
            {
                timer = 0;
                targetIndex += 1;
                if (targetIndex > targets.Count - 1)
                {
                    targetIndex = 0;
                }
            }
        }
    }
}
