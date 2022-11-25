using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissapear : MonoBehaviour
{
  public GameObject jogador;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Nota"))
        {
            jogador.SetActive(false);
        }
    }

    
}
