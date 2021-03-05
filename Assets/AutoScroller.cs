using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroller : MonoBehaviour
{
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
        if(scrolling)
            camera.transform.position = camera.position + new Vector3(ScrollSpeed*Time.deltaTime,0,0);
    }
}
