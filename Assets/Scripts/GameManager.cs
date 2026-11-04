using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private Animator animator;

    public Transform respawn_position;

    public TextMeshProUGUI timeTest;
    [SerializeField]
    private bool stop_time = false;

    private float time = 0f;

    

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (timeTest == null || stop_time)
        {
            return;
        }
        time += Time.deltaTime;
        timeTest.SetText("tiempo: " + TimeSpan.FromSeconds(time));
    }

    public void Animate_labyrinth(string animation)
    {
        animator.SetTrigger(animation);
    }

    public void restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
