using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Sprite[] targetSprite;

    [SerializeField] private BoxCollider2D cd;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float cooldown;
    private float timer;

    private int sushiCreated;
    private int sushiMilestone = 25;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = cooldown;
            sushiCreated++;

            if (sushiCreated > sushiMilestone && cooldown > .5f)
            {
                sushiMilestone += 10;
                cooldown -= .3f;
            }


            GameObject newTarget = Instantiate(targetPrefab);

            float randomX = Random.Range(cd.bounds.min.x, cd.bounds.max.x);

            newTarget.transform.position = new Vector2(randomX, transform.position.y);

            int randomIndex = Random.Range(0, targetSprite.Length);
            newTarget.GetComponent<SpriteRenderer>().sprite = targetSprite[randomIndex];

        }
    }
}
