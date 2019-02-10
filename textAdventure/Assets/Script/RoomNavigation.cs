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

    public void AttemptToChangeRooms(string[] directionNoun)
    {

        foreach (KeyValuePair<string, Room> check in exitDictionary)
        {
            string checkword = check.Key;

            for (int i = 0; i < directionNoun.Length; i++)
            {
                if (checkword.Contains(directionNoun[i]))
                {
                    if (exitDictionary.ContainsKey(directionNoun[i]))
                    {
                        currentRoom = exitDictionary[directionNoun[i]];
                        // controller.LogStringWithReturn("You changed" + directionNoun);
                        controller.DisplayRoomText();
                    }
                }
                else
                {
                    controller.LogStringWithReturn("oh well " + directionNoun[i] + "looks weird answer to me,are you sure about that?");

                }
            }
        }
    }
    public void ClearExits() {
        exitDictionary.Clear();
    }
}
