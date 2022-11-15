using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiverHandler : MonoBehaviour
{
    [SerializeField] public  ScriptableObject_NPCDialogue FirstQuestDialogueSO;
    [SerializeField] public ScriptableObject_NPCDialogue SecondQuestDialogueSO;

    [SerializeField] Text DialogueUI;
    [SerializeField] Text ObjectiveUI;

    private int QuestStartIndex = 0;
    private int QuestEndIndex = 0;

    private bool IsInRange = false;
    private bool HasStartedSecondQuest = false;


    // Start is called before the first frame update
    void Start()
    {
        if (DialogueUI)
            DialogueUI.enabled = false;
        if (ObjectiveUI)
            ObjectiveUI.enabled = false;

        FirstQuestDialogueSO.UpdateQuestState(false);
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

    void HandleSecondDialogueUI()
    {
        if (!IsInRange) return;
        if (!HasStartedSecondQuest) return;

        if (!SecondQuestDialogueSO.HasGivenQuest())
            DialogueUI.text = SecondQuestDialogueSO.QuestStartDialogue[QuestStartIndex];

        else if (SecondQuestDialogueSO.HasGivenQuest() && !SecondQuestDialogueSO.HasFinishedQuest())
            DialogueUI.text = SecondQuestDialogueSO.QuestStartDialogue[SecondQuestDialogueSO.QuestStartDialogue.Length - 1];

        else if (SecondQuestDialogueSO.HasFinishedQuest())
            DialogueUI.text = SecondQuestDialogueSO.QuestEndDialogue[QuestEndIndex];

        if(Input.GetKeyDown(KeyCode.E) && !SecondQuestDialogueSO.HasGivenQuest())
        {
            QuestStartIndex++;
            DialogueUI.text = SecondQuestDialogueSO.QuestStartDialogue[QuestStartIndex];
        }

        else if (Input.GetKeyDown(KeyCode.E) && SecondQuestDialogueSO.HasFinishedQuest())
        {
            DialogueUI.text = SecondQuestDialogueSO.QuestEndDialogue[QuestEndIndex];

            if ((QuestEndIndex + 1) <= (SecondQuestDialogueSO.QuestEndDialogue.Length - 1)) QuestEndIndex++;

            if (QuestEndIndex == SecondQuestDialogueSO.QuestEndDialogue.Length - 1)
            {
                //Do something here when the quest is finished and exhausted all quest end dialogue
            }
        } // Cycle through the QuestEndDialogue array dynamically


        if (QuestStartIndex == SecondQuestDialogueSO.QuestStartDialogue.Length - 1 && !SecondQuestDialogueSO.HasGivenQuest())
        {
            SecondQuestDialogueSO.UpdateQuestState(true);
            ObjectiveUI.enabled = true;
            ObjectiveUI.text = SecondQuestDialogueSO.QuestObjectiveString;

        } // If we exhausted all QuestStartDialogue and we havent given the quest, update the quest state to given

    }

    void HandleDialogueUI()
    {
        if (!IsInRange) return;
        if (HasStartedSecondQuest) return;

        if(!FirstQuestDialogueSO.HasGivenQuest())
            DialogueUI.text = FirstQuestDialogueSO.QuestStartDialogue[QuestStartIndex]; // When you enter the trigger, load the corresponding message. If we havent recieved the quest and we exited before recieving it, load the last message given
        
        else if(FirstQuestDialogueSO.HasGivenQuest() && !FirstQuestDialogueSO.HasFinishedQuest())
        {
            DialogueUI.text = FirstQuestDialogueSO.QuestStartDialogue[FirstQuestDialogueSO.QuestStartDialogue.Length - 1];
        } // Just as a safety, if you recieved the quest but havent finished it, load the last message on QuestStartDialogue Array

        else if(FirstQuestDialogueSO.HasFinishedQuest())
        {
            DialogueUI.text = FirstQuestDialogueSO.QuestEndDialogue[QuestEndIndex];
        } // If you have finished the quest and exited the dialogue before exhausting it, load the last message given

        if(Input.GetKeyDown(KeyCode.E) && !FirstQuestDialogueSO.HasGivenQuest())
        {
            QuestStartIndex++;
            DialogueUI.text = FirstQuestDialogueSO.QuestStartDialogue[QuestStartIndex];
        } // Cycle through the QuestStartDialogue array dynamically

        else if(Input.GetKeyDown(KeyCode.E) && FirstQuestDialogueSO.HasFinishedQuest())
        {
            DialogueUI.text = FirstQuestDialogueSO.QuestEndDialogue[QuestEndIndex];

            if ((QuestEndIndex + 1) <= (FirstQuestDialogueSO.QuestEndDialogue.Length - 1)) QuestEndIndex++;

            if(QuestEndIndex == FirstQuestDialogueSO.QuestEndDialogue.Length - 1)
            {
                //Do something here when the quest is finished and exhausted all quest end dialogue
                HasStartedSecondQuest = true;
                QuestStartIndex = 0;
                QuestEndIndex = 0;
            }
        } // Cycle through the QuestEndDialogue array dynamically

        if (QuestStartIndex == FirstQuestDialogueSO.QuestStartDialogue.Length - 1 && !FirstQuestDialogueSO.HasGivenQuest())
        {
            FirstQuestDialogueSO.UpdateQuestState(true);
            ObjectiveUI.enabled = true;
            ObjectiveUI.text = FirstQuestDialogueSO.QuestObjectiveString;

        } // If we exhausted all QuestStartDialogue and we havent given the quest, update the quest state to given

       

    }

}
