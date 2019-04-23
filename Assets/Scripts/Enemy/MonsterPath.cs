using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPath : MonoBehaviour
{   
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    int waypointIndex = 0;

    public float chaseSpeed;
    public Transform[] targets = new Transform[3];
    public bool lettingKnowCollision = false;
    public bool thereisaPMeat = false;
    public Transform realTarget; 
   
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // 몬스터경로돌게하는 함수와 고기먹고죽는애니메이터같이 있음
    void Update()
    {   if (!thereisaPMeat)
        {
            if (!lettingKnowCollision)
                Move();
        }
        if (transform.position == GameObject.Find("PoisonMeat").GetComponent<Transform>().position)
        {

        }
     
        
    }

    private void Move()
    {
        if (waypointIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position
            , waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);


            if ((int) transform.position.x * 1000 == (int) waypoints[waypointIndex].transform.position.x * 1000)
                waypointIndex += 1;
        }
        else
        {
            waypointIndex = 0;
        }
    }
    public void Chasing()
    {
        transform.position = Vector2.MoveTowards(transform.position, realTarget.position
            , chaseSpeed * Time.deltaTime);
    }
    
    
    
    
    
}
