using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleporter;
    public bool active = false;
    public GameObject player;
    public GameObject camera;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position ,transform.position);
        if(distance<=0.5 && Input.GetKeyDown(KeyCode.E) && active){
            player.transform.position = teleporter.position;
            camera.transform.position = new Vector3(teleporter.position.x,teleporter.position.y,-10);
            audioSource.Play();
        }
        
    }

	private void OnTriggerEnter2D(Collider2D other){


    }

    public Transform getteleportTO(){
        return teleporter;
    }

    
}
