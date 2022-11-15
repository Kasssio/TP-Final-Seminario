using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpMedialunita : MonoBehaviour
{

    bool medialunaHasBeenPickedUp = false;
    [SerializeField] GameObject Jero;
    [SerializeField] Text ObjectiveUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Jero.GetComponent<QuestGiverHandler>().FirstQuestDialogueSO.FinishQuest();
            ObjectiveUI.text = Jero.GetComponent<QuestGiverHandler>().FirstQuestDialogueSO.OnQuestEndObjective;

            gameObject.SetActive(false);
        }
    }




}
