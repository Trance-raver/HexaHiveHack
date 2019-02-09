using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;
    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    GameControlller controller;
    void Awake() {
        controller = GetComponent<GameControlller>();
    }

    public void UnpackExitsInRoom() {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            controller.interaction.Add(currentRoom.exits[i].exitDesc);
        }
    }

    public void AttemptToChangeRooms(string directionNoun) {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn("You changed" + directionNoun);
            controller.DisplayRoomText();
        }
        else {
            controller.LogStringWithReturn("oh well" + directionNoun+"looks weird answer to me,are you sure about that?");

        }
    }
    public void ClearExits() {
        exitDictionary.Clear();
    }
}
