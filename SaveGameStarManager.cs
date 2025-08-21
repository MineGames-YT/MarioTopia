using UnityEngine;

public class SaveGameStarManager : MonoBehaviour
{
    public GameObject _playerPrefab;
    public Transform SpawnPoint;
    public bool PlayerInZone;
    public Animator anim;
    public int saveGameNameCount;
    public int saveGameNameDefault;
    public bool PressFdone;
    public int numberSaveObject;
    void Start()
    {
        saveGameNameCount = PlayerPrefs.GetInt("SaveGame" + numberSaveObject, saveGameNameDefault);        
    }

    void Update()
    {
        if (PressFdone && PlayerInZone)
        {
            PlayerPrefs.SetInt("SaveGame" + numberSaveObject, numberSaveObject);
            PlayerPrefs.Save();
            anim.Play("SaveStarAnim");
            PressFdone = false;
            PlayerInZone = false;
            saveGameNameCount = PlayerPrefs.GetInt("SaveGame" + numberSaveObject, saveGameNameDefault); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = false;
        }
    }
}
