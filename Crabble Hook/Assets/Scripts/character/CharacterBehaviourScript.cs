using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourScript : MonoBehaviour
{
    //Movement var

    
    [SerializeField] public float speed = 10f;
    [SerializeField] public float speedRatio = .05f;

    public float speedStart;

    public float horizontalInput;

    //GrappleHook Var

    public Camera m_Camera;
    public LineRenderer m_LineRenderer;
    public DistanceJoint2D m_DistanceJoint2D;
    public Rigidbody2D m_Rigidbody2D;

    public Vector2 mPos;
    public float grappleDistance;

    public bool isGrappled;

    public RaycastHit2D hit;
   
    


    // Start is called before the first frame update
    void Start()
    {
        
        m_DistanceJoint2D.enabled = false;
        isGrappled = false;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Movement
       // if(isGrappled == false)
       // {
            horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(new Vector2(horizontalInput, 0) * Time.deltaTime * speed);
        // }


        //addit so when you are swinging you cant move

        //Grapple Hook

        grappleDistance = grappleDistance - (speedRatio * speed);
        m_DistanceJoint2D.distance = grappleDistance;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {


            // Shot//
            Vector3 shootCorrection = new Vector3(0, 0, 5);

            hit = Physics2D.Raycast(transform.position, ((Camera.main.ScreenToWorldPoint(Input.mousePosition) + shootCorrection - transform.position)), Mathf.Infinity);


            // GRAPPLE

            isGrappled = true;

            //  mPos = Input.mousePosition;

            //   Vector2 shootPos = (Vector2)m_Camera.ScreenToWorldPoint(mPos);

            grappleDistance = hit.distance; 


            Vector2.Angle(transform.position, hit.point);

            if (hit.point.x != 0)
            {

               
                m_DistanceJoint2D.connectedAnchor = hit.point;
                m_DistanceJoint2D.enabled = true;

                m_LineRenderer.SetPosition(0, hit.point);
                m_LineRenderer.SetPosition(1, transform.position);
                m_LineRenderer.enabled = true;
            }


        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))

        { 
            m_DistanceJoint2D.enabled = false;
            m_LineRenderer.enabled = false;
            isGrappled = false;
        }
        if (m_DistanceJoint2D.enabled)
        {
            m_LineRenderer.SetPosition(1, transform.position);
        }

    }
}
