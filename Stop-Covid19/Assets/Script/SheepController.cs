using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour
{

    Vector3 mousePos;
    public float moveSpeed = 1.5f;
    public float minX = -1.7f;
    public float maxX = 1.61f;
    public float minY = -3.4f;
    public float maxY = 1.78f;
    private GameObject gameController;
    // Use this for initialization
    void Start()
    {
        mousePos = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos = new Vector3(Mathf.Clamp(mousePos.x, minX, maxX), Mathf.Clamp(mousePos.y, minY, maxY), 0);
        }
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        gameController.GetComponent<GameController>().EndGame();
    }
}