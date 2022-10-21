using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoxes: MonoBehaviour
{
    // Start is called before the first frame update

    //ekraný ikiye böl bi yerden. üstteyken force vermeyi býrak. alttayken de sürekli random force ver.

    const float forceConstant = 100f;
    [SerializeField] public float forceValue;

    public PlayerController playerController;
    public GameManager gmScript;
    public CubePath cPath;

    private Vector3 forceVector;
    private Vector3 errorVector;
    private Vector3 cubePos;

    private Rigidbody cubeRigidbody;

    public int deneme;

    public GameObject player;
    public GameObject gmObject;

    private float upperRange;
    private float lowerRange;
    public float errorFloat;
    public int maxError = 5;
    public float totalScore;

    void Start()
    {
        //InvokeRepeating("ApplyForce", 0.2f, 0.2f);
        //InvokeRepeating("CheckPosition", 0, 0.5f);
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        forceValue = Random.Range(18f, 54f);
        cubeRigidbody  = GetComponent<Rigidbody>();
        gmObject = GameObject.Find("GameManager");
        gmScript = gmObject.GetComponent<GameManager>();
        cPath = gameObject.GetComponent<CubePath>();
    }

    // Update is called once per frame
        
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        CheckPosition();

        //cubePos = new Vector3(transform.position.x, cPath.roundedFloat, transform.position.z);

        ////transform.position = cubePos;

        //Debug.Log(cubePos.x + " " + " " + cubePos.y + " " + " " + cubePos.z);

    }

    void CheckPosition()
    {
        errorVector = transform.position - player.transform.position;
        errorFloat = Mathf.Abs(transform.position.y - player.transform.position.y);

        if (cPath.flag == 0)
        {
            totalScore += (20 / gmScript.playTime) * (maxError - errorFloat) * Time.fixedDeltaTime;
            Debug.Log("in");

            if (totalScore < 0)
            {
                totalScore = 0;
            }

        } else if (cPath.flag == 1)
        {
            totalScore = 0;
        }

        

    }
}
