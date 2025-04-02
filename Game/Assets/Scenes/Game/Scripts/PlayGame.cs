using UnityEngine;

public class PlayGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject characterPrefab; // Reference to the prefab
    public Transform spawnPoint; // Where to spawn the character

    void Start()
    {
        // Instantiate the character at the spawn point
        GameObject newPlayer = Instantiate(characterPrefab, spawnPoint.position, Quaternion.identity);
        Camera.main.GetComponent<CameraFollow>().player = newPlayer.transform;
    }
}
