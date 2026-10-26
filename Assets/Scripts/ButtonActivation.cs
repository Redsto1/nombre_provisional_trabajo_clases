using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    public GameManager gamemanager;

    [SerializeField]
    private string Animation_type;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gamemanager.Animate_labyrinth(Animation_type);
        }
    }
}
