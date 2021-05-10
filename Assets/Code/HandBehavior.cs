using System;
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
        HashSet<InputNames> inp = Main.State.ActiveInputs;

        if (which_hand == Hands.Left)
        {
            if (Main.State.PlayerView == PlayerView.LookingForward)
            {
                if (inp.Contains(InputNames.lh_left)) { transform.position += Vector3.left * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.lh_right)) { transform.position += Vector3.right * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.lh_up)) { transform.position += Vector3.up * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.lh_down)) { transform.position += Vector3.down * (hand_speed * Time.deltaTime); }
            } 
            else if (Main.State.PlayerView == PlayerView.LookingDown)
            {
                if (inp.Contains(InputNames.lh_left)) { transform.position += Vector3.left * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.lh_right)) { transform.position += Vector3.right * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.lh_up)) { transform.position += Vector3.forward * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.lh_down)) { transform.position += Vector3.back * (hand_speed * Time.deltaTime); }
            }
        }

        if (which_hand == Hands.Right)
        {
            if (Main.State.PlayerView == PlayerView.LookingForward)
            {
                if (inp.Contains(InputNames.rh_left)) { transform.position += Vector3.left * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.rh_right)) { transform.position += Vector3.right * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.rh_up)) { transform.position += Vector3.up * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.rh_down)) { transform.position += Vector3.down * (hand_speed * Time.deltaTime); }
            } 
            else if (Main.State.PlayerView == PlayerView.LookingDown)
            {
                if (inp.Contains(InputNames.rh_left)) { transform.position += Vector3.left * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.rh_right)) { transform.position += Vector3.right * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.rh_up)) { transform.position += Vector3.forward * (hand_speed * Time.deltaTime); }
                if (inp.Contains(InputNames.rh_down)) { transform.position += Vector3.back * (hand_speed * Time.deltaTime); }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // this isn't happening right now b/c we've removed the colliders from the laundry
        if (other.gameObject.CompareTag("Laundry"))
        {
            Debug.Log("bonked the towel!");
            other
                .gameObject
                .GetComponent<FoldableBehavior>()
                .AddTouchingHand(this.gameObject, which_hand);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Laundry"))
        {
            Debug.Log("moving off the towel");
            other
                .gameObject
                .GetComponent<FoldableBehavior>()
                .RemoveTouchingHand(which_hand);
        }
    }
}