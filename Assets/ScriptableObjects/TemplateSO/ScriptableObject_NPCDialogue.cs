using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NPCDialogue", menuName = "NPCDialogue Instance")]
public class ScriptableObject_NPCDialogue : ScriptableObject
{

    [SerializeField] public string[] QuestStartDialogue;
    [SerializeField] public string QuestObjectiveString;

    [SerializeField] public string[] QuestEndDialogue;
    [SerializeField] public string OnQuestEndObjective;

    private bool bHasGivenQuest = false;
    private bool bHasFinishedQuest = false;

    public bool HasGivenQuest()//False if quest hasnt been given, true if has been given
    {
        return bHasGivenQuest;
    }

    public bool HasFinishedQuest()
    {
        return bHasFinishedQuest;
    }

    public void UpdateQuestState(bool HasStarted) // @param HasStarted: Set to true if you've given the quest.
    {
        bHasGivenQuest = HasStarted;
    }

    public void FinishQuest()
    {
        bHasFinishedQuest = true;
    }
}
