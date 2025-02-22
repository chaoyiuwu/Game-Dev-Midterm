using UnityEngine;

public class Brick : MonoBehaviour {
    public int life;
    void Start() {

    }
    void OnCollisionEnter2D(Collision2D collision) {
        life--;
        if (life == 2) {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 255f);
        }

        if (life == 1) {
            GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
        }
        
        if (life <=0) {
            Destroy(gameObject);
            GameManager.Instance.DestroyedBricksPlus();
        }
    }
}
