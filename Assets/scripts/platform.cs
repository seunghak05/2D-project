using UnityEngine;

public class platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        stepped = false;
        for (int i = 0; i < obstacles.Length; i++)
        {
         if(Random.Range(0, 3) == 0)
         {
             obstacles[i].SetActive(true);
         }
         else
         {
             obstacles[i].SetActive(false);
         }
        }
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)

    {
        if(collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
        
    }
}
