using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
   [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    private float fieldOfView;
    private Vector3 origin;
    private float startingAngle;
    private float rotationAngle = 0f; // Track rotation angle
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fieldOfView = 17.5f; // också ett värde för field of view som kan justeras, behövde flytta upp för att andra metoder ska funka
        origin = Vector3.zero;
        
    }

    private void Update()
    { 
        //värden för field of view
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fieldOfView / rayCount;
        float viewDistance = 12.5f;

        // våra rays består av vertiser, vilket vi skapar här nedan
        // vår original vertis räknas som 1, sedan behöver vi för en triangel skapa en vertis vid 90, 45 och 0 grader = 4
        // rayCount här, räknar bara vertisen på 90 och 45 grader, inte den på 0 grader och original vertisen, därför står det inte bara 4 istället för rayCount + 1 +1
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];

        // vår uv ska ha samma sak så vi kan hämta våra värden från vertiserna för att hitta rätt längd
        Vector2[] uv = new Vector2[vertices.Length];

        // det ska va samma mängd trianglar som våra rays,
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        // gå igenom alla rays och lägg placera vertiser på rätt position
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            // If-satsen kollar efter kollisioner mellan synfätet och omvärlden, och anpassar synfätet utefter detta

            // kolla vad raycasten träffar för debug
            if (raycastHit2D.collider != null)
            {
                Debug.Log("Ray hit: " + raycastHit2D.collider.gameObject.name + " at position: " + raycastHit2D.point);
            }

            if (raycastHit2D.collider == null)
            {
                // om det inte träffar något sätts vertisen där den va på maximala distansen
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            } else {
                // om den träffar något sätter vi vertisen på den punkt där det kolliderade
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            //detta kommer skapa triangeln baserat på vertiserna, om  i > 0, för att detta inte kan köras på den första ray:n då den inte han en vertis att koppla till
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0; // vertisen på origin
                triangles[triangleIndex + 1] = vertexIndex - 1; // vertisen innan
                triangles[triangleIndex + 2] = vertexIndex; // den nuvarande vertisen

                triangleIndex += 3;

            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        // konverterar vinkeln till en vector3
        

        /*vertices[1] = new Vector3(50, 0);
        vertices[2] = new Vector3(0, -50);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;*/

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        // Set the aim direction in the FieldOfView component
        setRotationAngle(rotationAngle);

    }

    // New method to set the rotation angle
    public void setRotationAngle(float angle)
    {
        startingAngle = angle;
    }



static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

    }

    //följande tar en vector3 och returnerar en float
    static float GetAngleFromVectorFloat(Vector3 direction)
    {
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void setAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) - fieldOfView / 2f;
    }
}