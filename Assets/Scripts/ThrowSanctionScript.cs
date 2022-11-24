using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSanctionScript : MonoBehaviour
{
    GameObject SpawnedInstance;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject SanctionModel;
    [SerializeField] float ThrowPower = 0.1f;
    [SerializeField] int SanctionCount = 0;

    public bool CanSanction = false;

    private int TranscurredTranslations = 0;
    private bool CanInstance = true;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Mouse0) && CanSanction)
       {
            Instance();
       }
       Vector3 camDir = cam.transform.forward;
        Move();
    }

    void Instance()
    {
        Vector3 camDir = cam.transform.forward;
        if (SanctionCount <= 0) return;
        if (!CanInstance) return;

        SpawnedInstance = Instantiate(SanctionModel, cam.transform.position, cam.transform.rotation);
        //SpawnedInstance.transform.eulerAngles = cam.transform.forward * ThrowPower;
        SanctionModel.GetComponent<Rigidbody>().AddRelativeForce(camDir * ThrowPower);
        CanInstance = false;
        //for (int speed = 0; speed < 100; speed++)
        //{

        //}
    }
  

    void Move()
    {
        if (!SpawnedInstance) return;
        //SpawnedInstance.transform.position += SanctionModel.transform.localPosition; //missing end
        Vector3 camDir = cam.transform.forward;
        SpawnedInstance.transform.forward = camDir;
        SpawnedInstance.transform.Translate(0, 0, 0.5f);
        TranscurredTranslations++;

        if (TranscurredTranslations >= 5000) { Destroy(SpawnedInstance); TranscurredTranslations = 0; CanInstance = true; }

        //el problema está acá, habría que hacer que el proyectil viaje en la dirección en la que mira siempre
        //por ahi usando la rotacion local funciona (?)
    }

}
