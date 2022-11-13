using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiverHandler : MonoBehaviour
{
    [SerializeField] ScriptableObject_NPCDialogue QuestDialogueSO;
    [SerializeField] Text DialogueUI;
    [SerializeField] Text ObjectiveUI;

    private int QuestStartIndex = 0;
    private int QuestEndIndex = 0;
    private bool IsInRange = false;


    // Start is called before the first frame update
    void Start()
    {
        if (DialogueUI)
            DialogueUI.enabled = false;
        if (ObjectiveUI)
            ObjectiveUI.enabled = false;

        QuestDialogueSO.UpdateQuestState(false);
    }

    // Update is called once per frame
    void Update()
    {
        HandleDialogueUI();
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (!Other.gameObject.CompareTag("Player")) return;

        IsInRange = true;
        DialogueUI.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        IsInRange = false;
        DialogueUI.enabled = false;
    
    }


    void HandleDialogueUI()
    {
        if (!IsInRange) return;

        if(!QuestDialogueSO.HasGivenQuest())
            DialogueUI.text = QuestDialogueSO.QuestStartDialogue[QuestStartIndex]; // When you enter the trigger, load the corresponding message. If we havent recieved the quest and we exited before recieving it, load the last message given
        
        else if(QuestDialogueSO.HasGivenQuest() && !QuestDialogueSO.HasFinishedQuest())
        {
            DialogueUI.text = QuestDialogueSO.QuestStartDialogue[QuestDialogueSO.QuestStartDialogue.Length - 1];
        } // Just as a safety, if you recieved the quest but havent finished it, load the last message on QuestStartDialogue Array

        else if(QuestDialogueSO.HasFinishedQuest())
        {
            DialogueUI.text = QuestDialogueSO.QuestEndDialogue[QuestEndIndex];
        } // If you have finished the quest and exited the dialogue before exhausting it, load the last message given

        if(Input.GetKeyDown(KeyCode.E) && !QuestDialogueSO.HasGivenQuest())
        {
            QuestStartIndex++;
            DialogueUI.text = QuestDialogueSO.QuestStartDialogue[QuestStartIndex];
        } // Cycle through the QuestStartDialogue array dynamically

        else if(Input.GetKeyDown(KeyCode.E) && QuestDialogueSO.HasFinishedQuest())
        {
            DialogueUI.text = QuestDialogueSO.QuestEndDialogue[QuestEndIndex];

            if ((QuestEndIndex + 1) <= (QuestDialogueSO.QuestEndDialogue.Length - 1)) QuestEndIndex++;

            if(QuestEndIndex == QuestDialogueSO.QuestEndDialogue.Length - 1)
            {
                //Do something here when the quest is finished and exhausted all quest end dialogue
            }
        } // Cycle through the QuestEndDialogue array dynamically

        if (QuestStartIndex == QuestDialogueSO.QuestStartDialogue.Length - 1 && !QuestDialogueSO.HasGivenQuest())
        {
            QuestDialogueSO.UpdateQuestState(true);
            ObjectiveUI.enabled = true;
            ObjectiveUI.text = QuestDialogueSO.QuestObjectiveString;

        } // If we exhausted all QuestStartDialogue and we havent given the quest, update the quest state to given

       

    }

}
