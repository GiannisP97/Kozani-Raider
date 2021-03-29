using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuWalk : MonoBehaviour
{
    private Animator animator;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("State",2);
        transform.position += new Vector3(Time.deltaTime*2,0,0);

        if(transform.position.x>10){
            transform.position = startPosition;
        }
    }
}
