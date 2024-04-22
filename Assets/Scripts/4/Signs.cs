using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signs : MonoBehaviour, IInteractable
{
    [SerializeField] private int questIndex;    
    [SerializeField] private string tipo;    
    [SerializeField] private string objetivo;    

    private bool active = true;
    public void Interact()
    {
        if (active)
        {
            FindObjectOfType<QuestManager>().ActivarMision(questIndex, tipo, objetivo);
            active = false;
        }
    }
}
