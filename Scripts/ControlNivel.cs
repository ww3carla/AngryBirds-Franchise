using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlNivel : MonoBehaviour
{
    [SerializeField] string _numeNivelUrmator;//declaram variabila in care vom retine nivelul urmator

    Monstru[] _monstrii;//retinem colectia de monstrii intr-un vector

    void OnEnable()//metoda prin care vom tine minte cati monstrii avem
    {
        _monstrii = FindObjectsOfType<Monstru>();
    }


    void Update()
    {
        if (MonstriiSuntMorti())//verificam daca am distrus toti monstrii
            MergiNivelUrmator();//trece la urmatorul nivel
    }

    void MergiNivelUrmator()
    {
        Debug.Log("Mergi la " + _numeNivelUrmator);//trecem la nivelul urmator
        SceneManager.LoadScene(_numeNivelUrmator);//incarcam scena 
    }
    bool MonstriiSuntMorti()
    {
        foreach (var monstru in _monstrii)//parcurgem toti monstrii
        {
            if (monstru.gameObject.activeSelf)//verificam daca monstrii sunt activi
                return false;//returnam fals, inseamna ca nu sunt morti
        }

        return true;
    }

}
