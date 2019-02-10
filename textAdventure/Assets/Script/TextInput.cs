using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour{

    public InputField inputField;
    List<string> userdata = new List<string>();
    GameControlller controller;

    

    void Awake() {
        controller = GetComponent<GameControlller>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }
    
    void AcceptStringInput(string userInput){
        userInput = userInput.ToLower();
        userdata.Add(userInput);
        controller.LogStringWithReturn(userInput);

        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimiterCharacters);

       // for (int i = 0; i < controller.inputActions.Length; i++)
        {
          //  InputAction inputAction = controller.inputActions[i];
            // if (inputAction.keyword==separatedInputWords[0]) 
            {
                Debug.Log("done");
                //inputAction.RespondToInput(controller, separatedInputWords);
               
                controller.roomNavigation.AttemptToChangeRooms(separatedInputWords);
            }
        }

        InputComplete();
    }

    void InputComplete() {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }


}
