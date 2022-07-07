using UnityEngine;

public class GunScript : MonoBehaviour
{
  private GameObject _emptiness;
  private DataStorage _storage;
  private GameObject Target = null;
  private GameObject Arsenal; // Пока думаю

    private float LastCheck = 0f;
  private float LastShot = 0f;
  private float FireRate = 10f;
  private float Radius;
  private float Distance;
  private float NearestTarget;

  private void Awake()
  {
    _emptiness = GameObject.Find("DataStorage");
    _storage = _emptiness.GetComponent<DataStorage>();

    Radius = 25f;
    NearestTarget = 25f;
  }

  private void Update()
  {
    Self_managed();
  }

  private void Self_managed()
  {
     Tracking();

        if (Target == null)
            if (Time.time - this.LastCheck > 1f)
            {
                MinimumDistanceSearch();
                this.LastCheck = Time.time;
            }
            else
                Tracking();
    }

  private void Tracking()
  {
    if (Time.time - this.LastShot > this.FireRate)
    {
        Arsenal = Instantiate(_storage.Cannonball_Instance);
        Arsenal.GetComponent<ProjectileScript>().Test(Target.GetComponent<EnemyScript>());

        //Вызов метода с передачей цели в снаряд
        this.LastShot = Time.time;
    }
    transform.LookAt(Target.transform);

  }

  private void MinimumDistanceSearch() //Дописать
  {

    NearestTarget = 25f;

    foreach (var item in _storage.Enemies)
    {
      if (item != null)
      {

        Distance = Vector3.Distance(transform.position, item.transform.position);

        if (NearestTarget > Distance && Distance < Radius)
        {
          NearestTarget = Distance;
          Target = item;
        }

      }

    }

  }

}
