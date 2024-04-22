using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quest1;
    [SerializeField] private TextMeshProUGUI quest2;
    [SerializeField] private TextMeshProUGUI quest3;

    public bool quest1Active = false;
    public bool quest2Active = false;
    public bool quest3Active = false;

    public void ActivarMision(int questIndex, string tipo, string objetivo)
    {
        if (questIndex == 1)
        {
            quest1.text = $"{tipo}\n{objetivo}\nPresiona {questIndex} para cancelar misión";
            quest1Active = true;
        }
        else if (questIndex == 2)
        {
            quest2.text = $"{tipo}\n{objetivo}\nPresiona {questIndex} para cancelar misión";
            quest2Active = true;
        }
        else
        {
            quest3.text = $"{tipo}\n{objetivo}\nPresiona {questIndex} para cancelar misión";
            quest3Active = true;
        }
    }

    public void CancelarMision(int questIndex)
    {
        if (questIndex == 1 && quest1Active)
        {
            quest1.text = "Misión 1 cancelada";
            quest1Active = false;
        }
        if (questIndex == 2 && quest2Active)
        {
            quest2.text = "Misión 2 cancelada";
            quest2Active = false;
        }
        if (questIndex == 3 && quest3Active)
        {
            quest3.text = "Misión 3 cancelada";
            quest3Active = false;
        }
    }

    public void CompletarMision(int questIndex)
    {
        if (questIndex == 1)
        {
            quest1.text = $"Misión 1 COMPLETADA";
            quest1Active = false;
        }
        else if (questIndex == 2)
        {
            quest2.text = $"Misión 2 COMPLETADA";
            quest2Active = false;
        }
        else
        {
            quest3.text = $"Misión 3 COMPLETADA";
            quest3Active = false;
        }
    }
}
