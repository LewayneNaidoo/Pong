using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreController scoreController;
    public BallSoundController soundController;

    void BounceFromPaddle(Collision2D c)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 paddlePosition = c.gameObject.transform.position;

        float paddleHeight = c.collider.bounds.size.y;

        float x;
        if (c.gameObject.name == "Paddle1")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }

        float y = (ballPosition.y - paddlePosition.y) / paddleHeight;

        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x,y));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle1" || collision.gameObject.name == "Paddle2")
        {
            this.soundController.Bounce();
            this.BounceFromPaddle(collision);
        } else if (collision.gameObject.name == "WallLeft")
        {
            this.scoreController.GoalPlayer2();
            Debug.Log("Collision with WallLeft");
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "WallRight")
        {
            this.scoreController.GoalPlayer1();
            Debug.Log("Collision with WallRight");
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }

}
