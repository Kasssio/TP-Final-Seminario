using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpMedialunita : MonoBehaviour
{

    bool medialunaHasBeenPickedUp = false;
    [SerializeField] GameObject Jero;
    [SerializeField] Text ObjectiveUI;
    bool isInside = false;
    [SerializeField] TextMeshProUGUI InteractText;


    // Start is called before the first frame update
    void Start()
    {
        InteractText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInside) return;

        if(Input.GetKeyDown(KeyCode.E))
        {
            Jero.GetComponent<QuestGiverHandler>().FirstQuestDialogueSO.FinishQuest();
            ObjectiveUI.text = Jero.GetComponent<QuestGiverHandler>().FirstQuestDialogueSO.OnQuestEndObjective;

            InteractText.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = true;
            InteractText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractText.gameObject.SetActive(false);
    }




}
