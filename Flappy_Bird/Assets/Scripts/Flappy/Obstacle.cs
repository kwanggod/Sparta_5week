using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holesizeMin = 1f;
    public float holesizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    GameManager gamemanager;

    private void Start()
    {
        gamemanager= GameManager.instance;
    }
    public Vector3 SetRnadomPlace(Vector3 lastPosition, int obstaclCount)
    {
        float holeSize = Random.Range(holesizeMin, holesizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Move player = collision.GetComponent<Player_Move>();
        if (player != null)
            gamemanager.AddSocre(1);
    }
}
