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

        Vector3 CalculatedPosition = cam.transform.position;

        CalculatedPosition.y -= 1;
        CalculatedPosition += 1 * camDir;

        SpawnedInstance = Instantiate(SanctionModel, CalculatedPosition, cam.transform.rotation);
        SpawnedInstance.tag = "Nota";
        CanInstance = false;
    }
  

    void Move()
    {
        if (!SpawnedInstance) return;
    
        Vector3 camDir = cam.transform.forward;
        SpawnedInstance.transform.forward = camDir;
        SpawnedInstance.transform.Translate(0, 0, 0.5f);
        TranscurredTranslations++;

        if (TranscurredTranslations >= 100) { Destroy(SpawnedInstance); TranscurredTranslations = 0; CanInstance = true; }

       
    }

}
