using UnityEngine;

public class Player : MonoBehaviour
{
    private int pickupsCollected = 0;

    public void CollectPickup()
    {
        pickupsCollected++;
        Debug.Log("Pickups Collected: " + pickupsCollected);
    }

    // Other player-related code...
}
