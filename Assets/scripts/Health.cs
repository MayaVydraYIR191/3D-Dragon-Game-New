using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private CharacterController control;
    public int playerHealth;
    public GameObject RestartButton;
    public Image bar;
    public float fill;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        control = GetComponent<CharacterController>();
        fill = 1f;
        playerHealth = 5;
        control.enabled = true;
        RestartButton.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Danger")
        {
            fill = fill - 0.2f;
            bar.fillAmount = fill;
            playerHealth = (playerHealth - 1);
        }
        else if(other.gameObject.tag == "Restoration")
        {
            fill = fill + 0.2f;
            bar.fillAmount = fill;
            playerHealth = (playerHealth + 1);
        }
    }
    void Update()
    {
        if(playerHealth <= 0)
        {
            anim.SetBool("isDead", true);
            control.enabled = false;
            RestartButton.SetActive(true);
        }
    }
}
