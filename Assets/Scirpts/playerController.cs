using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; //랜덤 사용. 

public class playerController : MonoBehaviour
{
    public int playerControll = 3;
     public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject playerTogether;
    // public playerMove instance;

    // Start is called before the first frame update

    void Start()
    {

        // playerMove player_1 = GameObject.Find("Player_1").GetComponent<playerMove>();

        // player_1 = GameObeject.Find("Player_1")
    }

    // Update is called once per frame
    void Update()
    {
       
        playerMove player_1 = GameObject.Find("Player_1").GetComponent<playerMove>();
        playerMove player_2 = GameObject.Find("Player_2").GetComponent<playerMove>();
        playerMove player_3 = GameObject.Find("Player_3").GetComponent<playerMove>();
        playerMove player_Together = GameObject.Find("Player_Together").GetComponent<playerMove>();

        if (player_1.canMove == false && player_2.canMove == false && player_3.canMove == false && player_Together.canMove == false)
        {
            if (Input.GetKey("q"))
                ChoosePlayer(0);
            if (Input.GetKey("w"))
                ChoosePlayer(1);
            if (Input.GetKey("e"))
                ChoosePlayer(2);
            if (Input.GetKey("r"))
                ChoosePlayer(3);
        }

    }



    void ChoosePlayer(int playerControll)
    {
        FollowCam cam = GameObject.FindWithTag("MainCamera").GetComponent<FollowCam>();
        playerMove player_1 = GameObject.Find("Player_1").GetComponent<playerMove>();
        playerMove player_2 = GameObject.Find("Player_2").GetComponent<playerMove>();
        playerMove player_3 = GameObject.Find("Player_3").GetComponent<playerMove>();
        playerMove player_Together = GameObject.Find("Player_Together").GetComponent<playerMove>();
        playerJoin join_Together = GameObject.Find("Player_Together").GetComponent<playerJoin>(); //전체모임이 선택되었을때, 플레이어를 예쁘게 모이게 해주는아이


        switch (playerControll)
        {
            case 0:    //player1
                cam.target = cam.target1;
                player_1.Active = true;
                player_2.Active = false;
                player_3.Active = false;
                player_Together.Active = false;
                join_Together.Active = false;
                break;
            case 1:    //player2
                cam.target = cam.target2;
                player_1.Active = false;
                player_2.Active = true;
                player_3.Active = false;
                player_Together.Active = false;
                join_Together.Active = false;
                break;
            case 2:    //player3 
                cam.target = cam.target3;
                player_1.Active = false;
                player_2.Active = false;
                player_3.Active = true;
                player_Together.Active = false;
                join_Together.Active = false;
                break;
            case 3:   //전체컨트롤
                      //   Input.GetMouseDown(0); // 마우스 클릭위치로 이동 //일단 집합하고 못움직여야지. 
                cam.target = cam.target4;
                player_1.Active = false;
                player_2.Active = false;
                player_3.Active = false;
                join_Together.Active = true;
                break;
        }

    }
  
}  
