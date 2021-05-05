using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private bool already_swapped; // debounce the view swap key (dumb way to do this)
    [SerializeField] private GameObject forward_camera_position_marker;
    [SerializeField] private GameObject overhead_camera_position_marker;
    
    void Start()
    {
        Main.State.PlayerView = PlayerView.LookingForward; // bad idea to set this here, probably, lol
        already_swapped = false;
    }

    void Update()
    {
        // TODO: figure out how to animate this camera move
        if (Main.State.ActiveInputs.Contains(InputNames.view_swap))
        {
            if (!already_swapped)
            {
                
                already_swapped = true;
                if (Main.State.PlayerView == PlayerView.LookingForward)
                {
                    transform.position = overhead_camera_position_marker.transform.position;
                    transform.rotation = overhead_camera_position_marker.transform.rotation;
                    Main.State.PlayerView = PlayerView.LookingDown;
                } 
                else if (Main.State.PlayerView == PlayerView.LookingDown)
                {
                    transform.position = forward_camera_position_marker.transform.position;
                    transform.rotation = forward_camera_position_marker.transform.rotation;
                    Main.State.PlayerView = PlayerView.LookingForward;
                }
            }
        }
        else
        {
            already_swapped = false;
        }
    }
}
