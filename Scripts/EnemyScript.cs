using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject _emptiness;
    private DataStorage _storage;

    private GameObject[] Waypoints;
    private float speed = 0.02f;
    private int point = 0;

    private void Awake()
    {
        _emptiness = GameObject.Find("DataStorage");
        _storage = _emptiness.GetComponent<DataStorage>();

        Waypoints = _storage.Waypoints;
    }

    private void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        if (Waypoints[point] != null && point <= Waypoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[point].transform.position, speed);
            Vector3 direction = (Waypoints[point].transform.position - transform.position).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10f);

            if (transform.position == Waypoints[point].transform.position)
            {
                if (Waypoints.Length - 1 > point)
                    point++;
                else if(Waypoints.Length - 1 == point)
                    Destroy(gameObject);
            }
        } 
    }
}
