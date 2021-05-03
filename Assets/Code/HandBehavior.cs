using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hands
{
    Left, Right
}

public class HandBehavior : MonoBehaviour
{
    [SerializeField] public Hands which_hand;
    [SerializeField] public float hand_speed;
    
    void Start()
    {
    }

    void Update()
    {
        if (which_hand == Hands.Left)
        {
            if (Main.State.ActiveInputs.Contains(InputNames.lh_left))
            {
                transform.position += Vector3.left * (hand_speed * Time.deltaTime);
            }
            if (Main.State.ActiveInputs.Contains(InputNames.lh_right))
            {
                transform.position += Vector3.right * (hand_speed * Time.deltaTime);
            }
            if (Main.State.ActiveInputs.Contains(InputNames.lh_up))
            {
                transform.position += Vector3.up * (hand_speed * Time.deltaTime);
            }
            if (Main.State.ActiveInputs.Contains(InputNames.lh_down))
            {
                transform.position += Vector3.down * (hand_speed * Time.deltaTime);
            }
        }

        if (which_hand == Hands.Right)
        {
            if (Main.State.ActiveInputs.Contains(InputNames.rh_left))
            {
                transform.position += Vector3.left * (hand_speed * Time.deltaTime);
            }
            if (Main.State.ActiveInputs.Contains(InputNames.rh_right))
            {
                transform.position += Vector3.right * (hand_speed * Time.deltaTime);
            }
            if (Main.State.ActiveInputs.Contains(InputNames.rh_up))
            {
                transform.position += Vector3.up * (hand_speed * Time.deltaTime);
            }
            if (Main.State.ActiveInputs.Contains(InputNames.rh_down))
            {
                transform.position += Vector3.down * (hand_speed * Time.deltaTime);
            }
        }
    }
}
