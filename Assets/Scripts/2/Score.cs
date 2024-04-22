using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int puntaje = 0;

    public void ActualizarPuntaje(int puntos)
    {
        puntaje += puntos;

        scoreText.text = $"Score: {puntaje.ToString("D5")}";
    }    
}
