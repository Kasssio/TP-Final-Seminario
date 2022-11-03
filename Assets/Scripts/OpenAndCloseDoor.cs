using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseDoor : MonoBehaviour
{
    [SerializeField] private Animator myAnimController;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            myAnimController.SetBool("PlayOpen", true);
            myAnimController.SetBool("PlayClose", false);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            myAnimController.SetBool("PlayOpen", false);
            myAnimController.SetBool("PlayClose", true);

        }
    }
}
