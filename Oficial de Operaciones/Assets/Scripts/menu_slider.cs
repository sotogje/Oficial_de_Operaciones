using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_slider : MonoBehaviour
{
    public GameObject panel;
    public void mostrar_menu()
    {
        if (panel != null)
        {
            Animator animator = panel.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("mostrar");
                animator.SetBool("mostrar", !isOpen);
            }
        }
    }
}