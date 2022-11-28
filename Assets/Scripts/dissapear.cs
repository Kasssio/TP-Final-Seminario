using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissapear : MonoBehaviour
{
    [SerializeField] GameObject jogador;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Nota"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowSanctionScript>().IncrementStudentHitCounter();

            jogador.SetActive(false);
        }
    }

    
}
