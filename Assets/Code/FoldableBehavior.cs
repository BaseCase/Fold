using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldableBehavior : MonoBehaviour
{
    [SerializeField] public GameObject touching_left_hand;
    [SerializeField] public GameObject touching_right_hand;
    
    void Start()
    {
    }

    void Update()
    {
        // TODO: why is this null comparison expensive? It's not obvious to me...
        if (touching_left_hand != null && Main.State.ActiveInputs.Contains(InputNames.lh_grip))
        {
            // lol none of this works how I was hoping. I don't know how to Unity!
            // Vector3 contact_point = my_collider.ClosestPoint(touching_left_hand.transform.position);
            // Debug.Log($"GRIPPING AT {contact_point}");
            // mesh_vertices_buffer = my_mesh.vertices;
            // mesh_vertices_buffer[0] = touching_left_hand.transform.position;
            // my_mesh.vertices = mesh_vertices_buffer;
            // my_mesh.Optimize();
        }
    }

    public void AddTouchingHand(GameObject hand, Hands which_hand)
    {
        if (which_hand == Hands.Left)
        {
            touching_left_hand = hand;
        }

        if (which_hand == Hands.Right)
        {
            touching_right_hand = hand;
        }
    }

    public void RemoveTouchingHand(Hands which_hand)
    {
        if (which_hand == Hands.Left)
        {
            touching_left_hand = null;
        }

        if (which_hand == Hands.Right)
        {
            touching_right_hand = null;
        }
    }
}
