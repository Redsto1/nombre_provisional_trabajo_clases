using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;
public class man : MonoBehaviour
{

    [SerializeField]
    CharacterMovement player;
    [SerializeField]
    GameObject[] Texts;
    [SerializeField]
    GameObject last_text;
    [SerializeField]
    Image Dialogue_box;
    [SerializeField]
    int current_text = 0;
    bool reading = false;

    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/wooden_key.json";

    key_class keygen = new key_class();

    private void Start()
    {
        keygen.key = "01110111 01101000 01100101 01110010 01100101 00100000 01110100 01101000 01100101 00100000 01100110 01101111 01110010 01100101 01110011 01110100 00100000 01110111 01101111 01110101 01101100 01100100 00100000 01100111 01110010 01101111 01110111";

    }
    private void Update()
    {
        if (InputSystem.actions["Click"].WasPressedThisFrame())
        {
            pass_text();
        }
    }

    class key_class
    {
        public string key;
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
        else
        {
            Texts[current_text].SetActive(false);
            current_text++;
            if (current_text +1 > Texts.Length)
            {
                set_selection();
                return;
            }
            Texts[current_text].SetActive(true);
        }
    }

    private void set_selection()
    {
        reading = false;
    }

    public void accept()
    {
        string json = JsonUtility.ToJson(keygen);
        Debug.Log(json);
        File.WriteAllText(desktopPath, json);
        last_text.active = true;
        end_dialogue();
    }

    public void decline()
    {
        end_dialogue();
    }

    public void end_dialogue()
    {
        Dialogue_box.gameObject.SetActive(false);
        player.allow_movement = true;
        reading = false;
        last_text.active = false;
        foreach (var item in Texts)
        {
            item.SetActive(false);
        }
    }
}
