using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
  //1
  public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);
  //2
  private Transform target;
    void Start()
    {
    //3
    target = GameObject.Find("Player").transform;
    }
  //4
    void LateUpdate()
    {
    //5
    this.transform.position = target.TransformPoint(camOffset);
    //6
    this.transform.LookAt(target);
    }
}
/*
 * 1. Deklaracja zmiennej Vector3 ktora przechowuje dystans pomiedzy Main Camera i *CAPSULE*, mozna recznie zmieniac x, y, i z. 
 * 2.Zmienna ktora przechowuje informacje Transform gracza, access modifier na prywatny bo nie chce zeby bylo dostepne poza tą klasą
 * 3. GameObject.Find znajduje GameObject o takiej nazwie i przechowuje informacje o pozycji x, y i z gracza w zmiennej target.
 * 4. LateUpdate to jedna z metod klasy MonoBehaviour, wykonuje się PO update, a w update wykonuje się ruch gracza, wiec taka kolejnosc jest najlepsza
 * 5. 
 */