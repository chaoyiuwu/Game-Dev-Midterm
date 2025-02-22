using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance {get; private set;}

    public Rigidbody2D ballRigidbody;
    public float ballSpeed = 5f;
    public Vector2 ballStartingPos = new Vector2(0, -3.6f);
    private Vector2 currentVelocity;

    public int lifeCount = 3;
    public const int brickCount = 5;
    public int destroyedBricks = 0;

    public Vector2 getCurrentVelocity(){
        return currentVelocity;
    }
    public void setCurrentVelocity(Vector2 newVelocity){
        currentVelocity = newVelocity;
        ballRigidbody.linearVelocity = currentVelocity;
    }

    public void LoseLife() {
        Debug.Log("Oops!");
        lifeCount--;
        if (lifeCount == 0) {
            Debug.Log("Game Over!");
            StopGame();
        }
        else {
            ResetBall();
        }
    }

    public void DestroyedBricksPlus() {
        destroyedBricks++;
        if (destroyedBricks == brickCount) {
            Debug.Log("You Won!");
            StopGame();
        }
    }

    private void Awake() {    
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

    private void StopGame() {
        Time.timeScale = 0;
    }
    private void ResetBall() {
        ballRigidbody.transform.position = ballStartingPos;

        // slight horizontal variation
        float randX = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(randX, 1f).normalized;
        setCurrentVelocity(direction * ballSpeed);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
