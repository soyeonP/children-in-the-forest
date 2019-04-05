using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public GameObject Position;

    public Animator animator;
    public bool Active = true;
    public float moveSpeed = 1;
    public bool join = false;
    public bool canMove = false; // true일때 변경불가 false면 캐릭터변경가능. 
    Vector3 curPos; //현재위치
    Vector3 endPos; //갈위치 
    Vector3 dir; // 방향 구함 
    Vector3 Point;

    public Vector3 finalPos; //최종 목적지 (마우스클릭좌표) 
    float step; //한걸음 

    GameObject player_Together;
    GameObject topPoint;
    GameObject leftPoint;
    GameObject rightPoint;
    public LayerMask units;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
 
    void Start()
    {
        //  yAxis = gameObject.transform.position.y;
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
     
    }
    // Update is called once per frame
    void Update()
    {
        topPoint = GameObject.FindGameObjectWithTag("topPoint");
        leftPoint = GameObject.FindGameObjectWithTag("leftPoint");
        rightPoint = GameObject.FindGameObjectWithTag("rightPoint");
        if (Active)
        {

            if (Position == topPoint || Position == leftPoint || Position == rightPoint)
            {
                topPoint.transform.DetachChildren();
                leftPoint.transform.DetachChildren();
                rightPoint.transform.DetachChildren();
            }
            //마우스로 이동할 위치 받기 
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

               // Ray2D ray = new Ray2D(wp, Vector2.zero);

               // RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

              //  if (hit.collider != null) //체크용 
                {
                   // Debug.Log(wp); // wp랑 hit.point 랑 똑같네 뭘까. 

                }

                finalPos = wp; //vector3로 변환 
                curPos = transform.position;


                dir = finalPos - curPos; //방향 길이  
                dir.Normalize();
                canMove = true; //true일때 변경불가 false면 캐릭터변경가능. 


            }

                if (canMove)
                {
                    step = Time.deltaTime * moveSpeed;
                    curPos = transform.position;
                    endPos = finalPos - curPos; // 도착위치 = 최종도착- 현재 
                    if (endPos.magnitude <= step)
                    {
                    animator.SetFloat("Magnitude", dir.magnitude);
                    canMove = false;  //true일때 변경불가 false면 캐릭터변경가능.
                }
                    else
                    {
                        transform.position = curPos + (dir * step);
                    }
               animator.SetFloat("Horizontal", dir.x);
                animator.SetFloat("Vertical", dir.y);
                animator.SetFloat("Magnitude", dir.magnitude);
            }
        
           // Move(finalPos); // 에러있음. 추후 함수화 
           //false가 자주 잘 안먹는다. 어떡하지?
        }

        if ( join )
        {

            playerJoin player_Together = GameObject.Find("Player_Together").GetComponent<playerJoin>();

           if (Position == topPoint) // Point위치 정의. top or left or right 
            {
                Point = topPoint.transform.position;
            }

           else if (Position == leftPoint) // Point위치 정의. top or left or right 
            {
                 Point = leftPoint.transform.position;
            }

          else  if (Position == rightPoint) // Point위치 정의. top or left or right 
            {
                 Point = rightPoint.transform.position;
            }

          // Debug.Log("MoveForJoin " + Point);
            dir = Point - curPos;
            dir.Normalize();
            step = Time.deltaTime * moveSpeed;
            curPos = transform.position;
            endPos = Point - curPos; // 도착위치 = 최종도착- 현재 

            if (endPos.magnitude >= step)
            {

             //   Debug.Log("MoveForJoinDO " + Point);
                transform.position = curPos + (dir * step);
            }
            else
            {
                animator.SetFloat("Magnitude", dir.magnitude);
                //Debug.Log("도착해쪙");
                join = false;
                player_Together.Active = false;
                //차일드화 

                if (Position == topPoint) // Point위치 정의. top or left or right 
                {
                    transform.SetParent(topPoint.transform);
               //     Debug.Log("엄마");
                }

                else if (Position == leftPoint) // Point위치 정의. top or left or right 
                {
                    transform.SetParent(leftPoint.transform);
                }

                else if (Position == rightPoint) // Point위치 정의. top or left or right 
                {
                    transform.SetParent(rightPoint.transform);
                }
           
            }

        }




    }
        /*
        public void MoveForJoin( Vector2 finalPos) // 플레이어가 이동해야하는데 toghether가이동하고있다. 
        {
            step = Time.deltaTime * moveSpeed;

            player_Together = GameObject.FindGameObjectWithTag("Group");

            Vector3 hitPos = new Vector3(finalPos.x, finalPos.y, 0);
            Vector3 dir = hitPos - transform.position;
            dir.Normalize();
            curPos = transform.position;
            endPos = hitPos - curPos;
            if (endPos.magnitude <= step)
            {
                transform.SetParent(player_Together);
            } //도착 / 차일드화 
           else 
            {
                transform.position = curPos + (dir * step);
            }
            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
            animator.SetFloat("Magnitude", dir.magnitude);
            //도착하면 정지. 그 위치에서 투게더의 차일드화 . 

        }
        */
      private void OnCollisionEnter2D(Collision2D collision) //직선으로 가는데 물체에 닿으면 위치가 조금 바뀌면서 그 위치에 닿질 않아서 안멈추는거 같아 
    {
        Debug.Log("으악");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("으악");
        }
    }
    



    /*
    public void Move(Vector3 finalPos)
    {
        dir = finalPos - curPos; //방향 길이  
        dir.Normalize();

        canMove = true; 

        if (canMove)
        {

            step = Time.deltaTime * moveSpeed;
            curPos = transform.position;
            endPos = finalPos - curPos; // 도착위치 = 최종도착- 현재 
            if (endPos.magnitude <= step)
            {
                canMove = false;
                Debug.Log("이동상태falseJoin");
            }
            else
            {
                transform.position = curPos + (dir * step);
                Debug.Log("else문Join실행될때");
            }
            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
            animator.SetFloat("Magnitude", dir.magnitude);
        }

      

    }
    */
}







/*

if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude,endPoint.magnitude))
{
    Debug.Log("flag");
    gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, endPoint,
        1 / (duration * (Vector2.Distance(gameObject.transform.position, endPoint))));
}
else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
{
    flag = false;
    Debug.Log("I am here");
}

*/
/*
if (Active == true)
{
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

    animator.SetFloat("Horizontal", movement.x);
    animator.SetFloat("Vertical", movement.y);
    animator.SetFloat("Magnitude", movement.magnitude);


    transform.position = transform.position + movement * Time.deltaTime * moveSpeed;

}
*/
