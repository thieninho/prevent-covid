using UnityEngine;
using System.Collections;

public class WolfController : MonoBehaviour
{

    public GameObject boom;
    public float minBoomTime = 2;
    public float maxBoomTime = 4;
    private float boomTime = 0;
    private float lastBoomTime = 0;
    public float throughBoomTime = 0.5f;
    private GameObject Sheep;
    private Animator anim;
    private GameObject gameController;
    // Use this for initialization
    void Start()
    {
        UpdateBoomTime();
        Sheep = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastBoomTime + boomTime)
        {
            ThroughBoom();
        }
    }

    void UpdateBoomTime()
    {
        lastBoomTime = Time.time;
        boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }

    void ThroughBoom()
    {
        GameObject bom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;

        bom.GetComponent<BoomController>().target = Sheep.transform.position;

        UpdateBoomTime();
        gameController.GetComponent<GameController>().GetPoint();
    }
}
