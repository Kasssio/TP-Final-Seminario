using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleController : MonoBehaviour
{
    [SerializeField] bool running = false;
    [SerializeField] bool idle = true;
    [SerializeField] bool left = false;
    [SerializeField] bool right = false;
    [SerializeField] Animator ControllerAnimations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            idle = false;
            running = true;
            left = false;
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            running = false;
            idle = false;
            left = true;
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            running = false;
            idle = false;
            left = false;
            right = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            idle = true;
            running = false;
            left = false;
            right = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            running = false;
            idle = true;
            left = false;
            right = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            running = false;
            idle = true;
            left = false;
            right = false;
        }
        if (running)
        {
            ControllerAnimations.Play("running");
        }
        if (idle)
        {
            ControllerAnimations.Play("idle");
        }
        if (left)
        {
            ControllerAnimations.Play("left turn");
        }
        if (running)
        {
            ControllerAnimations.Play("right turn");
        }
    }
}
