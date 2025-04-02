using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{

    private SpriteRenderer sr;
    public Sprite frog1;
    public Sprite frog2;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void sprite1() {
        sr.sprite = frog1;
    }

    public void sprite2() {
        sr.sprite = frog2;
    }
}
