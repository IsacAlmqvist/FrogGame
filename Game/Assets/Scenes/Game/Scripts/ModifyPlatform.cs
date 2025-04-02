using UnityEngine;

public class ModifyPlatform : MonoBehaviour
{
    public SpriteRenderer sr;
    public Transform tr;
    public Sprite grass;
    public Sprite rock;
    public Sprite bounce;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();

        if (tr == null || sr == null)
        {
            Debug.LogError("Component is missing from the GameObject.");
        }
    }

    public void SetBounce() {
        sr.sprite = bounce;
    }
    public void SetFragile() {
        sr.sprite = rock;
    }
    public void SetGrass() {
        sr.sprite = grass;
    }

    public void SetScale(float x) {
        tr.localScale = new Vector3(tr.localScale.x * x, tr.localScale.y, tr.localScale.z);
    }

    // public void SetPos(float x, float y) {
    //     tr.position = new Vector3(x, y, tr.position.z);
    // }
}
