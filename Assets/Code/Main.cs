using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameState
{
    public GameMode CurrentMode;
    public PlayerView PlayerView;
    public HashSet<InputNames> ActiveInputs;
}

public enum GameMode { Playing }
public enum PlayerView { LookingForward, LookingDown }

public enum InputNames
{
    lh_left,
    lh_right,
    lh_up,
    lh_down,
    lh_grip,
    rh_left,
    rh_right,
    rh_up,
    rh_down,
    rh_grip,
    view_swap,
}

public class Main : MonoBehaviour
{
    public static GameState State;

    private void Awake()
    {
        // TODO: this needs to be a singleton; instead of relying on convention it's probably a good idea to enforce that.
        //        What's the pattern for doing that in Unity? Just do it? Does it have to be attached to an object still?
        Debug.Log("Booting up...");
        State.CurrentMode = GameMode.Playing;
        State.PlayerView = PlayerView.LookingForward;
        State.ActiveInputs = new HashSet<InputNames>();
    }

    void Update()
    {
        { // check current inputs and handle appropriately
            if (State.CurrentMode == GameMode.Playing)
            {
                if (Input.GetKey("a")) { State.ActiveInputs.Add(InputNames.lh_left); } else { State.ActiveInputs.Remove(InputNames.lh_left); }
                if (Input.GetKey("d")) { State.ActiveInputs.Add(InputNames.lh_right); } else { State.ActiveInputs.Remove(InputNames.lh_right); }
                if (Input.GetKey("w")) { State.ActiveInputs.Add(InputNames.lh_up); } else { State.ActiveInputs.Remove(InputNames.lh_up); }
                if (Input.GetKey("s")) { State.ActiveInputs.Add(InputNames.lh_down); } else { State.ActiveInputs.Remove(InputNames.lh_down); }
                if (Input.GetKey(KeyCode.LeftShift)) { State.ActiveInputs.Add(InputNames.lh_grip); } else { State.ActiveInputs.Remove(InputNames.lh_grip); }
                if (Input.GetKey("left")) { State.ActiveInputs.Add(InputNames.rh_left); } else { State.ActiveInputs.Remove(InputNames.rh_left); }
                if (Input.GetKey("right")) { State.ActiveInputs.Add(InputNames.rh_right); } else { State.ActiveInputs.Remove(InputNames.rh_right); }
                if (Input.GetKey("up")) { State.ActiveInputs.Add(InputNames.rh_up); } else { State.ActiveInputs.Remove(InputNames.rh_up); }
                if (Input.GetKey("down")) { State.ActiveInputs.Add(InputNames.rh_down); } else { State.ActiveInputs.Remove(InputNames.rh_down); }
                if (Input.GetKey(KeyCode.RightShift)) { State.ActiveInputs.Add(InputNames.rh_grip); } else { State.ActiveInputs.Remove(InputNames.rh_grip); }
                if (Input.GetKeyDown("x")) { State.ActiveInputs.Add(InputNames.view_swap); } else { State.ActiveInputs.Remove(InputNames.view_swap); }
            }
        }        
    }
}
