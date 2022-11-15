using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSanctionScript : MonoBehaviour
{
    GameObject SpawnedInstance;

    [SerializeField] GameObject SanctionModel;
    [SerializeField] float ThrowPower = 1;
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

        Move();
    }

    void Instance()
    {
        if (SanctionCount <= 0) return;
        if (!CanInstance) return;
        SpawnedInstance = Instantiate(SanctionModel, transform.position, transform.rotation);
        CanInstance = false;
    }
  

    void Move()
    {
        if (!SpawnedInstance) return;
        SpawnedInstance.transform.position += new Vector3(ThrowPower, 0, 0);
        TranscurredTranslations++;

        if (TranscurredTranslations >= 50) { Destroy(SpawnedInstance); TranscurredTranslations = 0; CanInstance = true; }
    }

}
