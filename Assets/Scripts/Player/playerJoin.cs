using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJoin : MonoBehaviour     //전체모임이 선택되었을때, 플레이어를 예쁘게 모이게 해주는아이 .
{
    Vector2 current; 
    public Vector2 topPoint, leftPoint, rightPoint;
    public bool Active = false;
    public bool canMove = false;
    public Vector3 topPos;
    public Vector3 leftPos;
    public Vector3 rightPos;

    ArrayList dirLength = new ArrayList();
    public float[] dirLen;

    public playerMove player_1;
    public playerMove player_2;
    public playerMove player_3;




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Active)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Ray2D ray = new Ray2D(wp, Vector2.zero);

                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null) //체크용 
                {
                    Debug.Log(wp);
                }

                transform.position = wp;
                Debug.Log("현재위치:" + transform.position);

                current = transform.position; // 현재 오브젝트 위치

                ////삼각형 위치 셋팅 벡터방법//////
                /*     topPoint.x = current.x;
                   topPoint.y = (current.y + 0.15f);
                    leftPoint.x = (current.x - 0.3f);
                     leftPoint.y = (current.y - 0.3f);
                   rightPoint.x = (current.x + 0.3f);
                     rightPoint.y = (current.y + 0.3f); */

                playerMove player_Together = GameObject.Find("Player_Together").GetComponent<playerMove>();
                GameObject top = transform.Find("topPoint").gameObject;
                GameObject left = transform.Find("leftPoint").gameObject;
                GameObject right = transform.Find("rightPoint").gameObject;

                //Debug.Log(top.transform.position); child position 위치 받아오기 
                topPos = top.transform.position;
                leftPos = left.transform.position;
                rightPos = right.transform.position;

               Debug.Log("MoveJoin" + topPos);

                //player의 포지션 설정  player_1 과 t / r/ l  거리 구하기 
                // length[]= { 1t 2l 3 r , 1t 2r 3l , 2t 1l 3r  , 2t 3l 1r ,3t 1l 2r , 3t 2l 1r};   
                
                float t1l2r3 = DistanceToPoint(topPos, player_1.transform.position) + DistanceToPoint(leftPos, player_2.transform.position) + DistanceToPoint(rightPos, player_3.transform.position);
                float t1r2l3 = DistanceToPoint(topPos, player_1.transform.position) + DistanceToPoint(leftPos, player_3.transform.position) + DistanceToPoint(rightPos, player_2.transform.position);
                float t2l1r3 = DistanceToPoint(topPos, player_2.transform.position) + DistanceToPoint(leftPos, player_1.transform.position) + DistanceToPoint(rightPos, player_3.transform.position);
                float t2l3r1 = DistanceToPoint(topPos, player_2.transform.position) + DistanceToPoint(leftPos, player_3.transform.position) + DistanceToPoint(rightPos, player_1.transform.position);
                float t3l1r2 = DistanceToPoint(topPos, player_3.transform.position) + DistanceToPoint(leftPos, player_1.transform.position) + DistanceToPoint(rightPos, player_2.transform.position);
                float t3l2r1 = DistanceToPoint(topPos, player_3.transform.position) + DistanceToPoint(leftPos, player_2.transform.position) + DistanceToPoint(rightPos, player_1.transform.position);

                dirLen = new float[6];
                dirLen[0] = t1l2r3;
                dirLen[1] = t1r2l3;    
                dirLen[2] = t2l1r3;
                dirLen[3] = t2l3r1;
                dirLen[4] = t3l1r2;
                dirLen[5] = t3l2r1;

                Debug.Log(dirLen[0]);

                int min = 0;
                for(int i = 1; i<6; i++)
                {
                    if (dirLen[min] > dirLen[i])
                        min =i;
                    Debug.Log("작은거 " + dirLen[min]);
                }

                switch (min) {

                    case 0:
                        player_1.Position = top;
                        player_2.Position = left;
                        player_3.Position = right;

                        break;
                    case 1:
                        player_1.Position = top;
                        player_2.Position = right;
                        player_3.Position = left;

                        break;
                    case 2:
                        player_1.Position = left;
                        player_2.Position = top;
                        player_3.Position = right;

                        break;
                    case 3:
                        player_1.Position = right;
                        player_2.Position = top;
                        player_3.Position = left;

                        break;
                    case 4:
                        player_1.Position = left;
                        player_2.Position = right;
                        player_3.Position = top;

                        break;
                    case 5:
                        player_1.Position = right;
                        player_2.Position = left;
                        player_3.Position = top;

                        break;
                }
               
                player_1.join = true;
                player_2.join = true;
                player_3.join = true;

                player_Together.Active = true;

                //가야하는 위치를 넣는다 . Point (top,left,right..)
               //  player_1.MoveforJoin(topPos); 
                //  player_2.MoveforJoin(leftPos);
                // player_3.MoveforJoin(rightPos);
                
            }
            // player_1.MoveForJoin(topPoint);  // 여기서 together가 캐릭터에 붙어버린다. 
            // MoveForJoin(player_2.transform.position, leftPoint);
            // MoveForJoin(player_3.transform.position, rightPoint);





          //  if (player_1.transform.position.x == topPoint.x) //집합했으면  Together실행 조인문은 종료한다. 
          //  {
        //        player_Together.Active = true;
        //        Active = false;
        //     return;
        //    }
            // if (player_1.canMove == false)
            //    Active = false;


        }//플레이어들 모이면 false로 돌리기 

    }

    public float DistanceToPoint(Vector3 a , Vector3 b)
    {
        Debug.Log("연산문");
        return (float)Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2));
    }
  
}
