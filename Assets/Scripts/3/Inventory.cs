using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<string> items  = new List<string>();

    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI ballsText;
    [SerializeField] private TextMeshProUGUI appleText;

    private int coinsAmount = 0;
    private int ballsAmount = 0;
    private int applesAmount = 0;
    private int inputAmount = 0;
    private string input;

    private void Update()
    {
        if (input != null)
            inputAmount = int.Parse(input);
    }

    public void AgregarObjeto(string item)
    {
        for (int i = 0; i < inputAmount; i++)
        {
            items.Add(item);
        }
    }

    public void QuitarObjeto(string item)
    {
        for (int i = 0; i < inputAmount; i++)
        {
            items.Remove(item);
        }
    }

    public void ReadStringInput(string s)
    {
        input = s;
    }

    public void UpdateUI()
    {
        coinsAmount = 0;
        ballsAmount = 0;
        applesAmount = 0;

        foreach (string item in items)
        {
            if (item == "Coin")
                coinsAmount++;
            else if (item == "Ball")
                ballsAmount++;
            else
                applesAmount++;
        }

        coinsText.text = $"x{coinsAmount.ToString("D2")}";
        ballsText.text = $"x{ballsAmount.ToString("D2")}";
        appleText.text = $"x{applesAmount.ToString("D2")}";
    }
}
