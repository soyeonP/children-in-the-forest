using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * 0.2f);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * 0.2f);

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector2.up * 0.2f);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector2.down * 0.2f);
    }
}
