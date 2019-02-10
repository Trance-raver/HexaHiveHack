using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="textAdventure/InputAction/Go")]

public class Go : InputAction
{
    public override void RespondToInput(GameControlller controller, string[] separatedInputWords) {
     //   controller.roomNavigation.AttemptToChangeRooms(separatedInputWords[0]);
    }
}
