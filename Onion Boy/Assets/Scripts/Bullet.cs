using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    [SerializeField] private GameObject dustPrefab;


    void Update() => transform.right = rb.velocity;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            GameObject newDust = Instantiate(dustPrefab, collision.transform.position, Quaternion.identity);
            newDust.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
            Destroy(newDust, 3);

            Destroy(collision.gameObject);
            Destroy(gameObject);

            UI.instance.AddScore();
        }
    }
}
