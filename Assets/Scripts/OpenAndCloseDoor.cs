using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseDoor : MonoBehaviour
{
    private Animation animacion;
    // Start is called before the first frame update
    void Start()
    {
        animacion = gameObject.GetComponent<Animation>();
        animacion.Stop("PuertaCerrada");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            animacion.Play("PuertaCerrada");
        }
    }
}
