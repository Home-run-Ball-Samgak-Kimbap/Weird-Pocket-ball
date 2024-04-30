using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSystem : MonoBehaviour
{
    public LineRenderer cueLineRenderer;
    private ScreenTouchManager screenTouchManager;
    private Vector3 forceDirection;
    private float forceMagnitude;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "BallDestroy")
            Destroy(gameObject);
        
    }

    public void OnLineRenderer()
    {
        cueLineRenderer.enabled = true;
    }
    public void DrowLineRenderer(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Vector3 endPosition = new Vector3(ray.GetPoint(10f).x, transform.position.y, ray.GetPoint(10f).z);
        cueLineRenderer.SetPosition(0, transform.position);
        cueLineRenderer.SetPosition(1, endPosition);//mousePosition);
        //forceDirection = (ray.GetPoint(5f) - transform.position).normalized;
        forceDirection = (endPosition - transform.position).normalized;
        forceMagnitude = (endPosition - transform.position).magnitude * 500f;
    }

    public void AddForce()
    {
        cueLineRenderer.enabled = false;
        this.GetComponent<Rigidbody>().AddForce(forceDirection * forceMagnitude);
    }
}
