using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pasare : MonoBehaviour
{

    [SerializeField] float _fortaLansare = 300;//introducem un camp in meniul unity pentru a putea modifica forta de lansare
    [SerializeField] float _maxDistantaTragere = 5;//introducem un camp in meniul unity care va retine valoarea maxima a distantei de lansare prin tragere a pasarii

    Vector2 _pozitiaStart;//declarare variabila in care retinem pozitia initiala a pasarii
    Rigidbody2D _rigidbody2D;//declaram variabila in care vom retine Rigidbody2D pentru a da eficienta algoritmului
    SpriteRenderer _spriteRenderer;//declaram variabila in care vom retine SpriteRenderer pentru a da eficienta algoritmului

    void Awake()//functia care apeleaza toate componentele prima data
    {
        _pozitiaStart = transform.position;//salvam pozitia initiala a pasarii
        _rigidbody2D = GetComponent<Rigidbody2D>();//salvam pentru a da eficienta algoritmului
        _spriteRenderer = GetComponent<SpriteRenderer>();//salvam pentru a da eficienta algoritmului
    }

    void Update()//verificam daca pozitia pasarii s a schimbat si a intrecut limitele
    {
        if(transform.position.y > 10)//daca a intrecut limitele pe axa y
        {
            string numeScenaCurenta = SceneManager.GetActiveScene().name;//declaram numele scenei curente intr o variabila
            SceneManager.LoadScene(numeScenaCurenta);//preluam numele scenei curente si o reincarcam
        }

        if (transform.position.x > 30)//daca a intrecut limitele pe axa x
        {
            string numeScenaCurenta = SceneManager.GetActiveScene().name;//declaram numele scenei curente intr o variabila
            SceneManager.LoadScene(numeScenaCurenta);//preluam numele scenei curente si o reincarcam
        }

    }
    void Start()
    {
        _pozitiaStart = _rigidbody2D.position;//ii dam o valoare pozitiei initiale in care se afla pasarea
        _rigidbody2D.isKinematic = true;//controlam doar prin cod nu prin obiecte fizice
    }

    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;//schimbarea culorii in rosu la momentul selectarii pasarii
    }

    void OnMouseUp()
    {
        Vector2 pozitiaCurenta = _rigidbody2D.position;//salvam pozitia curenta
        Vector2 directia = _pozitiaStart - pozitiaCurenta;//scadem pozitia de start din pozitia curenta pentru a le pune intr-o directie
        directia.Normalize();//returnam valoarea normala a vectorului

        _rigidbody2D.isKinematic = false;//dezactivam controlul doar prin cod pentru a putea adauga forta de lansare a pasarii
        _rigidbody2D.AddForce(directia * _fortaLansare);//adaugam puterea de lansare a pasarii

        _spriteRenderer.color = Color.white;//schimbarea culorii in alb la momentul deselectarii pasarii
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//redarea pozitiei curosurului de la mouse in spatiul lumii create din camera principala

        Vector2 pozitiaDorita = mousePosition;//implementam vectorul unidimensional, pozitia dorita, care va retine doar coordonatele x si y;

        float distance = Vector2.Distance(pozitiaDorita, _pozitiaStart);//reda valoarea in metrii a distantei dintre cei doi parametrii
        if(distance>_maxDistantaTragere)//verificam daca distanta e prea mare
        {
            Vector2 direction = pozitiaDorita - _pozitiaStart;//stabilim directia de tragere pentru lansarea pasarii
            direction.Normalize();
            pozitiaDorita = _pozitiaStart + (direction * _maxDistantaTragere);//schimbam pozitia dorita ca sa fie punctul aflat la distanta maxima de tragere pentru lansare
        }

        if (pozitiaDorita.x > _pozitiaStart.x)//verificam daca suntem pozitionati la dreapta pozitiei de start
            pozitiaDorita.x = _pozitiaStart.x;

        _rigidbody2D.position = pozitiaDorita;//setam pozitia 
    }

    void OnCollisionEnter2D(Collision2D collision)//functie care detecteaza momentul in care pasarea loveste ceva
    {
        StartCoroutine(ResetareDupaIntarziere());//metoda pentru ca pasarea sa se reseteze la pozitia initiala dupa un anumit interval de timp
    }

    IEnumerator ResetareDupaIntarziere()//functie pentru numararea intervalului de timp
    {
        yield return new WaitForSeconds(3);//asteapta trei secunde iar apoi ruleaza urmatoarele linii de cod
        _rigidbody2D.position = _pozitiaStart;//va reseta pozitia initiala a pasarii
        _rigidbody2D.isKinematic = true;//setam pe kinematic ca sistemul sa nu controleze pasarea automat insa avem nevoie sa i setam viteza la 0 pentru a nu se reseta la nesfarsit 
        _rigidbody2D.velocity = Vector2.zero;//va opri pasarea
    }
}
