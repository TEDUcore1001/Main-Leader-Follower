using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
	public GameObject laserObject;

    public GameManager gm;

	public VolumetricLines.VolumetricLineBehavior laserScript;
	public bool laserTriggered;
    // Start is called before the first frame update
    void Start()
    {
		laserTriggered = false;
		laserObject = GameObject.FindGameObjectWithTag("Laser");
		laserScript = laserObject.GetComponent<VolumetricLines.VolumetricLineBehavior>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (laserTriggered)
        {
            laserScript.m_material.color = new Color(0, 10, 10, 0);
            laserScript.m_lineColor = new Color(0, 10, 10, 0);
            laserScript.LineColor = new Color(0, 10, 10, 0);
            laserScript.m_lightSaberFactor = 1F;
            laserScript.LineWidth = 2f;
        } else
        {
            laserScript.m_material.color = new Color(255, 0, 0 , 0);
            laserScript.m_lineColor = new Color(255, 0, 0, 0);
            laserScript.LineColor = new Color(255, 0, 0, 0);
            laserScript.m_lightSaberFactor = 1F;
            laserScript.LineWidth = 2f;
        }
    }

	private void OnTriggerEnter(Collider other)
	{

		if (gameObject.tag == "Enemy" && other.gameObject.tag == "Laser")
		{
			laserTriggered = true;
            //gm.soundEffects[1].Play();
			Debug.Log("Dart.");
		}

    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "Enemy" && other.gameObject.tag == "Laser")
        {
            laserTriggered = false;
            //gm.soundEffects[1].Stop();
        }
    }
}
