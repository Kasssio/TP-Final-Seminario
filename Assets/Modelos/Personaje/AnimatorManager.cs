using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] Animator AnimatorController;
    // Start is called before the first frame update
    void Start()
    {
        AnimatorController.Play("mixamo.com");
    }

    // Update is called once per frame
    void Update()
    {
        //AnimatorController.Play("mixamo.com");
    }
}
