using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class man : MonoBehaviour
{
    [SerializeField]
    CharacterMovement player;
    [SerializeField]
    GameObject[] Texts;
    [SerializeField]
    Image Dialogue_box;
    [SerializeField]
    int current_text = 0;

    bool reading = false;


    private void Update()
    {
        if (InputSystem.actions["Click"].WasPressedThisFrame())
        {
            pass_text();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player.allow_movement = false;
        reading = true;
        Dialogue_box.gameObject.SetActive(true);
        Texts[0].SetActive(true);
    }

    void pass_text()
    {
        if (reading == false)
        {
            return;
        }
        if (current_text > Texts.Length)
        {
            Dialogue_box.gameObject.SetActive(false);
            player.allow_movement = true;
            reading = false;
            foreach (var item in Texts)
            {
                item.SetActive(false);
            }
        }
        else
        {
            Texts[current_text].SetActive(false);
            current_text++;
            Texts[current_text].SetActive(true);
        }
    }

}
