using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator animator;

    public Transform respawn_position;

    public void Animate_labyrinth(string animation)
    {
        animator.SetTrigger(animation);
    }
}
