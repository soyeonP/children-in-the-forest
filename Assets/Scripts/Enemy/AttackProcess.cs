using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProcess : MonoBehaviour
{
    
    bool do_the_attack_alarm_finish = false;
    
    SpriteRenderer attackrange2;
    SpriteRenderer player1;
    SpriteRenderer player2;
    SpriteRenderer player3;
    public int blink_time;

    // Start is called before the first frame update
    void Start()
    {
        attackrange2 = GameObject.Find("AttackRange2").GetComponent<SpriteRenderer>();
        player1 = GameObject.Find("Player1").GetComponent<SpriteRenderer>();
        player2 = GameObject.Find("Player1").GetComponent<SpriteRenderer>();
        player3 = GameObject.Find("Player1").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void Update()
    {

    }

    IEnumerator Blinkeffect()
    {
       
        int count_blink_time = 0;


        while (count_blink_time < blink_time)
        {
            if (do_the_attack_alarm_finish)
                yield return null;

            if (count_blink_time%2 == 0)
            {
                attackrange2.color = new Color(255, 255, 255, 0.85f);
            }
            else
                attackrange2.color = new Color(255, 255, 255, 0.25f);

            yield return new WaitForSeconds(0.2f);

            count_blink_time ++;
        }

        attackrange2.color = new Color(255, 255, 255, 1);

        yield return null;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)//blink후에 플레이어들 hp깍임
    {
        float[] tempHP = new float[3];
        if (col.CompareTag("Player"))
        {
            StartCoroutine("Blinkeffect");
        }
        //blink 이펙트 재생된다음에 끝무렵에 체력깍이는지 확인하기
        if (col.name.Equals(player1))
        {
            tempHP[0] = player1.GetComponent<Animator>().GetFloat("HP");
            GetComponent<Animator>().SetFloat("HP", tempHP[0] - 20);
        }
        if (col.name.Equals(player2))
        {
            tempHP[1] = player1.GetComponent<Animator>().GetFloat("HP");
            GetComponent<Animator>().SetFloat("HP", tempHP[1] - 20);
        }
        if (col.name.Equals(player1))
        {
            tempHP[2] = player1.GetComponent<Animator>().GetFloat("HP");
            GetComponent<Animator>().SetFloat("HP", tempHP[2] - 20);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {   do_the_attack_alarm_finish = true;
            
        }
       
    }
}
