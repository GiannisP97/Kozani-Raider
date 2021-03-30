using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;
    private bool doorState = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disableDoor(){
        door.SetActive(false);
        doorState = false;
    }

    public void enableDoor(){
        door.SetActive(true);
        doorState = true;
    }

    public bool isOpened(){
        return doorState;
    }
}
