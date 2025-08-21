using UnityEngine;

public class GameBoyTrigger : MonoBehaviour
{
    public GameBoyMachine machine;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            machine.isPlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        machine.isPlayerInZone = false;
        machine.PressFdone = false;
    }
}
