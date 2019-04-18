using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetecting : MonoBehaviour
{
    int numberOfPlayerEntered = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            numberOfPlayerEntered++;

            GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[numberOfPlayerEntered -1]
                = col.transform;
           
        }
    }

    void OnTriggerStay2D(Collider2D col1)
    {
       
        if (col1.CompareTag("Player"))
            if(!(GameObject.Find("Enemy").GetComponent<MonsterPath>().thereisaPMeat))
                {
                    GameObject.Find("Enemy").GetComponent<MonsterPath>().lettingKnowCollision = true;
                    GameObject.Find("Enemy").GetComponent<MonsterPath>().realTarget = GameObject
                    .Find("Enemy").GetComponent<MonsterPath>().targets[0];
                    GameObject.Find("Enemy").GetComponent<MonsterPath>().Chasing();
                }

        if(col1.gameObject.name == "PMeat")
            {
                GameObject.Find("Enemy").GetComponent<MonsterPath>().thereisaPMeat = true;
                GameObject.Find("Enemy").GetComponent<MonsterPath>().realTarget 
                = GameObject.Find("PMeat").transform;
                GameObject.Find("Enemy").GetComponent<MonsterPath>().Chasing();

            }
  
    }

    private void OnTriggerExit2D(Collider2D col2)
    {
        if (col2.CompareTag("Player"))
        {
            numberOfPlayerEntered--;

            if (numberOfPlayerEntered == 0)//플레이어 다 나가면 몬스터move함수 작동시키고 이 함수종료시킴
            {
                GameObject.Find("Enemy").GetComponent<MonsterPath>().lettingKnowCollision = false;

                return;
            }

            if (col2.transform == GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[0])//0번째애가 나가면
            {
                if(numberOfPlayerEntered == 1)
                {//1번째애를 0번째로
                    GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[0]
                        = GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[1];
                }
                if(numberOfPlayerEntered == 2)
                {//마찬가지로 뒤에서부터 땡겨옴
                    GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[0]
                       = GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[1];
                    GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[1]
                       = GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[2];
                }                 
            }
            if (col2.transform == GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[1])//1번째가 나가면
            {
                GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[1]
                      = GameObject.Find("Enemy").GetComponent<MonsterPath>().targets[2];
            }
        }

        if (col2.gameObject.name == "PMeat")
        {
            GameObject.Find("Enemy").GetComponent<MonsterPath>().thereisaPMeat = false;
        }
    }
}
