using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
  private Transform camTransform;
  public GameObject directionLight;
  private Transform lightTransform;

    // Start is called before the first frame update
    void Start()
    {
    Weapon huntingBow = new Weapon("Hunting Bow",5);
    Character testowy = new Character();
    Paladin knight = new Paladin("Krol Arturek", huntingBow);

    knight.PrintStatsInfo();
    testowy.PrintStatsInfo();

    camTransform = this.GetComponent<Transform>();
    Debug.Log(camTransform.localPosition);

    //directionLight = GameObject.Find("Directional Light");

    lightTransform = directionLight.GetComponent<Transform>();
    Debug.Log(lightTransform.localPosition);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
