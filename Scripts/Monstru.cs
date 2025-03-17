using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class Monstru : MonoBehaviour
{
    public static event Action OnPlayerDeath;//functie care nu va lua parametrii, creeam un eveniment(ecranul de game over)
  
    [SerializeField] Sprite _spriteMoarte;//vom putea adauga animatii pentru momentul distrugerii monstrului
    [SerializeField] ParticleSystem _partcileSystem;//vom putea controla animatiile adugate in momentul distrugerii monstrului

    bool _aMurit;//declaram variabila prin care verificam daca a murit

    void OnCollisionEnter2D(Collision2D collision)//functie folosita pentru distrugerea monstrului
    {
        if(TrebuieSaMoaraDeLaImpact(collision))//verificam daca monstrul moare de la impact
        {
            StartCoroutine(Moare());//apelam IEnumerator de mai jos
        }
        
    }

    bool TrebuieSaMoaraDeLaImpact(Collision2D collision)
    {
        if (_aMurit)//verificam daca deja a murit 
        {
            return false;//nu a murit, continua pana ce moare de la un anumit impact
        }
            
        Pasare pasare = collision.gameObject.GetComponent<Pasare>();//verificam daca pasarea loveste
        if (pasare != null)//daca pasarea exista
            return true;//monstrul va muri de la impact

        if (collision.contacts[0].normal.y < -0.5)//verificam daca obiectul cade de deasupra monstrului
            return true;

        return false;
    }

    IEnumerator Moare()
    {
        _aMurit = true;
        Scor.scorValoare += 10;//crestem valoarea scorului dupa ce a murit
        GetComponent<SpriteRenderer>().sprite = _spriteMoarte;//aplicam efectul in momentul distrugerii monstrului
        _partcileSystem.Play();//vor aparea animatiile in momentul distrugerii monstrului
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);//facem ca monstrii sa fie inactivi
        OnPlayerDeath?.Invoke();//invocam evenimentul(ecranul de game over) creeat, prin ? stim ca nu este nul

    }

    

}

