using UnityEngine;

public class DataStorage : MonoBehaviour
{
  static public int Gold = 180;
  static public int Base_Health = 20;
   
  public GameObject Enemy_Instance;
  public GameObject Tower_Instance;
  public GameObject Cannonball_Instance;
  public GameObject Scaffolding_Instance;

  public GameObject[] Waypoints;
  public GameObject[] Enemies; //Отказаться от массива

  public AudioClip mistake;
  public AudioClip сonstruction;
}
