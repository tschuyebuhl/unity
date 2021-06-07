using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
  //1
  public float moveSpeed = 10f;
  public float rotateSpeed = 75f;
  //2
  private float vInput;
  private float hInput;

    // Update is called once per frame
    void Update()
    {
    //3
    vInput = Input.GetAxis("Vertical") * moveSpeed;
    //4
    hInput = Input.GetAxis("Horizontal") * rotateSpeed;
    //5
    this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
    //6
    this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }

 
}
/*1. dwie publiczne zmienne jako mnożniki: movespeed, czyli jak szybko gracz sie porusza przod/tyl
 *2. rotatespeed czyli jak szybko gracz sie obraca lewo/prawo
 *3. jest od wykrywania W/S 
 *4. wykrywanie klawiszy A/D
 *5. metoda Translate ktora przyjmuje jako parametr wektor3D zeby poruszyc komponent Transform gracza:
 *  this użyto w celu specyfikacji GameObjectu do ktorego jest przyczepiony skrypt
 *  Vector3 pomnozony przez Time.DeltaTime oraz vInput daje kierunek i predkosc w kierunku przod/tyl
 *  Time.DeltaTime to czas od ostatniej klatki, uzywa sie go zeby uniezaleznic predkosc gracza od fps urzadzenia.
 *6. Roatate w celu obrotu, refy do punktu 5. 
 */