using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scor : MonoBehaviour
{
    public static int scorValoare;
    public Text scor;

    void Start()
    {
        scorValoare = 0;//initializam valoarea variabilei in care retinem scorul cu 0 de fiecare data cand incepe jocul
        scor = GetComponent<Text>();//ii cream o referinta scorului
    }

    void Update()
    {
        scor.text = "SCORE: " + scorValoare;//ii dam valoarea scorului
    }
}
