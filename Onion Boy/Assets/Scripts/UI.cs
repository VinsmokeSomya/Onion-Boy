using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI ammoText;

    private int scoreValue;

    [SerializeField] private GameObject tryAgainButton;

    [Header("Reload details")]
    [SerializeField] private BoxCollider2D reloadWindow;
    [SerializeField] private GunController gunController;
    [SerializeField] private int reloadSteps;
    [SerializeField] private UI_ReloadButton[] reloadButtons;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        reloadButtons = GetComponentsInChildren<UI_ReloadButton>(true);
    }


    void Update()
    {
        if (Time.time >= 1)
            timerText.text = Time.time.ToString("#,#");

        if (Input.GetKeyDown(KeyCode.R))
            OpenReloadUI();
    }

    public void OpenReloadUI()
    {
        foreach (UI_ReloadButton button in reloadButtons)
        {
            button.gameObject.SetActive(true);

            float randomX = Random.Range(reloadWindow.bounds.min.x, reloadWindow.bounds.max.x);
            float randomY = Random.Range(reloadWindow.bounds.min.y, reloadWindow.bounds.max.y);

            button.transform.position = new Vector2(randomX, randomY);
        }

        Time.timeScale = .4f;
        reloadSteps = reloadButtons.Length;
    }

    public void AttemptToReload()
    {
        if (reloadSteps > 0)
            reloadSteps--;

        if (reloadSteps <= 0)
            gunController.ReloadGun();
    }

    public void AddScore()
    {
        scoreValue++;
        scoreText.text = scoreValue.ToString("#,#");
    }

    public void UpdateAmmoInfo(int currentBullets, int maxBullets)
    {
        ammoText.text = currentBullets + "/" + maxBullets;
    }

    public void OpenEndScreen()
    {
        Time.timeScale = 0;
        tryAgainButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
