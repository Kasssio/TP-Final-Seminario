using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsManager : MonoBehaviour
{
    bool HasToStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonJugar()
    {
        SceneManager.LoadScene("Tic L1 L2");
    }

    public void BotonSalir()
    {
        Application.Quit();
    }
}
