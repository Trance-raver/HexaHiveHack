using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlller : MonoBehaviour
{
    public InputAction[] inputActions;
    [HideInInspector] public List<string> interaction = new List<string>();
    [HideInInspector] public RoomNavigation roomNavigation;
    List<string> actionLog = new List<string>();
    public Text displayText;

    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();
    }

    public void DisplayRoomText()
    {
        ClearCollectionForNewRoom();
        UnpackRoom();
        actionLog.Clear();
        string joinedInteractionDesc = string.Join("\n", interaction);  
        string combinedText = roomNavigation.currentRoom.desp + "\n" + joinedInteractionDesc;
        LogStringWithReturn(combinedText);
        
    }

    public void DisplayLoggedText() {
        string logAsText = string.Join("\n",actionLog.ToArray());
        displayText.text = logAsText;
    }

    void Start() {
        DisplayRoomText();
        DisplayLoggedText();  
    }

    public void LogStringWithReturn(string stringToAdd) {
        actionLog.Add(stringToAdd + "\n");
    }

    void UnpackRoom() {
        roomNavigation.UnpackExitsInRoom();
    }

    void ClearCollectionForNewRoom() {
        interaction.Clear();
        roomNavigation.ClearExits();
    }

    void Update()
    {
        
    }
}
