using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("textAdventure/Room"))]
public class Room : ScriptableObject
{
    [TextArea]
    public string desp;
    public string roomName;
    public Exit[] exits;

}
