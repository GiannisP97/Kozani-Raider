using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroller : MonoBehaviour
{  
    public float speed = 1;
    public float fixing_speed_y = 1;
    public Transform camera;
    public bool scrolling = false;


    private bool adj = true;
    [SerializeField] private float ScrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = this.transform.position.y - camera.position.y;
        if(Mathf.Abs(dist)>=0.5 && camera.position.y>=0 && adj){
            camera.position = camera.position + new Vector3(0,dist*Time.deltaTime* fixing_speed_y,0);
        }
        
        if(camera.position.y<0){
            adj = false;
            camera.position = new Vector3(camera.position.x,0,camera.position.z);
        }
        else
            adj =true;
        if(scrolling)
            camera.transform.position = camera.position + new Vector3(ScrollSpeed*speed*Time.deltaTime,0,0);
    }
}
