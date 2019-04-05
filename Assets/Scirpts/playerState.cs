using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState : MonoBehaviour
{
    public float stamina= 10.0f;
    public float Hp = 10.0f ;
    public float Scare =10.0f ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //몬스터가 공격시 hp 감소
        if(stamina > 0)
        stamina -= (0.1f * Time.deltaTime);
           //플레이어 사망 클래스만들고/ 클래스 소환. 
        //음식아이템 섭취시 stamina 증가 

        
    }
}
