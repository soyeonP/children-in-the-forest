using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{ 
    public Transform target; 
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;

    public const float offsetX = 0f;
    public const float offsetY = 0f;
    public const float offsetZ = -10f;
    public float limitright = 2f;
    //public float limitleft = -2f;
    public float limittop = 2f;
    //public float limitbottom = -2f;

    public float followSpeed = 10.0f;

    private Transform tr;
    Vector3 cameraPosition; 
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
  

        cameraPosition = new Vector3 (target.position.x, target.position.y, offsetZ);

        if (target.position.x > limitright)
            cameraPosition.x = limitright;
        else if (target.position.x < -(limitright))
            cameraPosition.x = -(limitright);

        if (target.position.y > limittop)
            cameraPosition.y = limittop;
        else if (target.position.y < -(limittop))
            cameraPosition.y = -(limittop);

        transform.position = Vector3.Lerp(tr.position, cameraPosition, followSpeed * Time.deltaTime);
    }
}
