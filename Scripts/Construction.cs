using UnityEngine;

public class Construction : MonoBehaviour
{
    private GameObject _emptiness;
    private DataStorage _storage;
    private Outline outline;

    private bool EmptySpace = true; // Не дадим возможности создать два объекта в одной точке!!!

    private AudioSource Sound;

    private void Awake()
    {
       _emptiness = GameObject.Find("DataStorage");
       _storage = _emptiness.GetComponent<DataStorage>();

        Sound = GetComponent<AudioSource>();
        outline = GetComponent<Outline>();
    }
 
    private void OnMouseDown()
    {
        if (DataStorage.Gold >= 100 && EmptySpace == true)
            Building();
        else
            SoundError();
    }
    
    private void Building()
    {
        Instantiate(_storage.Tower_Instance, transform.position, new Quaternion(0f, 0f, 0f, 0f)); 
        DataStorage.Gold -= 100;
        EmptySpace = false;

        Sound.PlayOneShot(_storage.сonstruction);
        Destroy(gameObject, 1f);
    }
  
    private void SoundError() => Sound.PlayOneShot(_storage.mistake);

    private void OnMouseEnter() => OutlineIllumination();

    private void OnMouseExit() => outline.OutlineWidth = 0;

    private void OutlineIllumination()
    {
        outline.OutlineWidth = 2;

        if (DataStorage.Gold >= 100)
            outline.OutlineColor = Color.white;
        else
            outline.OutlineColor = Color.red;
    }
}
