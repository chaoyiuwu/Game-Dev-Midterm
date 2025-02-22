using UnityEngine;

public class BallMovement : MonoBehaviour {

    private const string PlayerTag = "Player";
    private const string WallTag = "Wall";
    private const string FloorTag = "Floor";
    private const string BricksTag = "Bricks";
    private Rigidbody2D rBody;

    AudioSource bleep;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rBody = GetComponent<Rigidbody2D>();
        bleep = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(PlayerTag)) {
            HandlePlayerCollision(other);
        }
        else if (other.gameObject.CompareTag(WallTag)) {
            HandleWallCollision();
        }
        else if(other.gameObject.CompareTag(FloorTag)){
            GameManager.Instance.LoseLife();
        }
        else {
            if(other.gameObject.CompareTag(BricksTag)){
                bleep.Play();
            }
            HandleVerticalCollision();
        }
    }

    private void HandleVerticalCollision() {
        Vector2 currentVeloicty = GameManager.Instance.getCurrentVelocity();
        currentVeloicty = new Vector2(currentVeloicty.x, currentVeloicty.y * -1);
        GameManager.Instance.setCurrentVelocity(currentVeloicty);
    }
    private void HandleWallCollision() {
        Vector2 currentVeloicty = GameManager.Instance.getCurrentVelocity();
        currentVeloicty = new Vector2(currentVeloicty.x * -1, currentVeloicty.y);
        GameManager.Instance.setCurrentVelocity(currentVeloicty);
    }

    // bounce off the player handle
    private void HandlePlayerCollision(Collision2D other) {
        Vector2 currentVeloicty = GameManager.Instance.getCurrentVelocity();
        
        // calculate bounce angle
        float x = CalculateBounceAngle(transform.position, other.transform.position, other.collider.bounds.size.x);
        currentVeloicty = new Vector2(x, currentVeloicty.y * -1).normalized * GameManager.Instance.ballSpeed;
        GameManager.Instance.setCurrentVelocity(currentVeloicty);
    }

    private float CalculateBounceAngle(Vector2 ballPos, Vector2 paddlePos, float PaddleLocation){
        return (ballPos.x - paddlePos.x) / PaddleLocation * 3f;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
