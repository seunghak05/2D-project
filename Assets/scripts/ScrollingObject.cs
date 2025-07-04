using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
    }
}
