using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroller : MonoBehaviour
{  
    public float speed = 1;
    public float fixing_speed_y = 1;
    public Transform camera;
    public bool scrolling = false;
    [SerializeField] private float ScrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = this.transform.position.y - camera.position.y;
        if(Mathf.Abs(dist)>1){
            camera.position = camera.position + new Vector3(0,dist*Time.deltaTime* fixing_speed_y,0);
        }
        if(scrolling)
            camera.transform.position = camera.position + new Vector3(ScrollSpeed*speed*Time.deltaTime,0,0);
    }
}
