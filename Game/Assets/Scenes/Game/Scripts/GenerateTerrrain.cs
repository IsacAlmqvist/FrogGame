using UnityEngine;

public class GenerateTerrrain : MonoBehaviour
{

    public float startX = 0; //from 0 to 8
    public float startY = -4; //to infinity and beyond
    public GameObject platformPrefab;
    public ModifyPlatform mp;
    public Transform spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn = GetComponent<Transform>();
        spawn.position = new Vector3(0, -4, 0);
        int j = 0;

        for(int i = 0; i < 1000; i++) {
            if(i <= 110) j++;
            int randomMaterial = Random.Range(1, 11 + j/10);
            float randomX = (float)Random.Range(0, 800)/100;
            float randomY = (float)Random.Range(90 + j, 200)/100;
            float randomScale = (float)Random.Range(40, 100 - j/6)/100;
            spawn.position = new Vector3(randomX - 4, spawn.position.y + randomY, 0);

            GameObject platform = Instantiate(platformPrefab, spawn.position, Quaternion.identity);
            mp = platform.GetComponent<ModifyPlatform>();
            spawn.position = new Vector3(0, spawn.position.y, 0);
            
            mp.SetScale(randomScale);

            if(randomMaterial == 10) {
                mp.SetBounce();
            } else if(randomMaterial > 8) {
                mp.SetFragile();
            } else {
                mp.SetGrass();
            }

        }
    }

}
