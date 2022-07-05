using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourScript : MonoBehaviour
{
    //Movement var

    [SerializeField] public float speed = 10f;

    public float speedStart;

    public float horizontalInput;

    //GrappleHook Var

    public Camera m_Camera;
    public LineRenderer m_LineRenderer;
    public DistanceJoint2D m_DistanceJoint2D;


    // Start is called before the first frame update
    void Start()
    {
        m_DistanceJoint2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement

        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(horizontalInput, 0) * Time.deltaTime * speed);

        //Grapple Hook

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 shootPos = (Vector2)m_Camera.ScreenToWorldPoint(Input.mousePosition);

            Vector2.Angle(transform.position, shootPos);
            m_DistanceJoint2D.connectedAnchor = shootPos;
            m_DistanceJoint2D.enabled = true;

            m_LineRenderer.SetPosition(0,shootPos);
            m_LineRenderer.SetPosition(1, transform.position);
            m_LineRenderer.enabled = true;



        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))

        { 
            m_DistanceJoint2D.enabled = false;
            m_LineRenderer.enabled = false;
        }
        if (m_DistanceJoint2D.enabled)
        {
            m_LineRenderer.SetPosition(1, transform.position);
        }

    }
}
