using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.IO;
using UnityEngine.TextCore.Text;
public class man : MonoBehaviour
{
    // si hacer esto es un problema porfavor comunicemelo de inmediato y elimino todo lo relacionado a esta parte del juego
    // fue hecho con fines completamente ludicos y esta separado de la experiencia normal del juego

    // Buenas tardes profesor si estas leyendo este codigo, significa que probablemente lo has encontrado
    // si no aqui te va una pista, en el tercer laberinto puedes tomar una ruta extraña usando las puertas giratorias,

    // en fin este codigo solo genera un json con una llave que se usara mas tarde en otro proyecto,
    // va a haber mas de una llave para la puerta asi que mucha suerte encontrandolas :D

    // Como ultima anotacion esta habitacion es una referencia a la habitacion del hombre olvidado de deltarune
    // no es la primera ni ultima vez que la veras en un proyecto mio, aunque creo que esta es la version mas 1 a 1 que he hecho.

    [SerializeField]
    CharacterMovement player;
    [SerializeField]
    GameObject[] Texts;
    [SerializeField]
    GameObject[] Texts_after_decision;
    [SerializeField]
    Image Dialogue_box;
    [SerializeField]
    int current_text = 0;
    [SerializeField]
    bool reading = false;
    [SerializeField]
    bool already_readed = false;

    bool Decision_made = false;

    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/wooden_key.json";

    key_class keygen = new key_class();
    [SerializeField]
    GameObject[] current_texts;

    private void Start()
    {
        current_texts = Texts;
        keygen.key = "01110111 01101000 01100101 01110010 01100101 00100000 01110100 01101000 01100101 00100000 01100110 01101111 01110010 01100101 01110011 01110100 00100000 01110111 01101111 01110101 01101100 01100100 00100000 01100111 01110010 01101111 01110111";
    }
    private void Update()
    {
        if (InputSystem.actions["Click"].WasPressedThisFrame() && reading == true)
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
        if (already_readed == true)
        {
            return;
        }
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
            current_texts[current_text].SetActive(false);
            current_text++;
            if (current_text +2 > current_texts.Length)
            {
                if (Decision_made == false)
                {
                    set_selection();
                }
                else
                {
                    end_dialogue();
                }
            }
            current_texts[current_text].SetActive(true);
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
        current_texts = Texts_after_decision;
        current_text = 0;
        reading = true;
        Decision_made = true;
        pass_text();
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
        current_text = 0;
        already_readed = true;
        foreach (var item in current_texts)
        {
            item.SetActive(false);
        }
    }
}
