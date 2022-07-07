using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private GameObject _emptiness;
    private DataStorage _storage;

    private bool Availability = true;

    private AudioSource Sound;

    private void Awake()
    {
        _emptiness = GameObject.Find("DataStorage");
        _storage = _emptiness.GetComponent<DataStorage>();

        Sound = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (Availability == true)
            Building();
        else
            SoundError();
    }

    private void Building()
    {
        Instantiate(_storage.Scaffolding_Instance, transform.position, new Quaternion(0f, 0f, 0f, 0f)); 
        DataStorage.Gold += 60;
        Availability = false;

        Sound.PlayOneShot(_storage.ñonstruction);
        Destroy(gameObject, 1f);
    }

    private void SoundError() => Sound.PlayOneShot(_storage.mistake);

}
