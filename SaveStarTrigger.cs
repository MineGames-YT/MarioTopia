using UnityEngine;

public class SaveStarTrigger : MonoBehaviour
{
    public SaveGameStarManager StarManager;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StarManager.PlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        StarManager.PlayerInZone = false;
        StarManager.PressFdone = false;
    }
}
