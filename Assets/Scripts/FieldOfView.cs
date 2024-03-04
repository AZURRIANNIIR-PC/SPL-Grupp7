using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        //värden för field of view
        float fieldOfView = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 2;
        float angle = 0f;
        float angleIncrease = fieldOfView/ rayCount;
        float viewDistance = 50f;

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
        for (int i = 0; i < rayCount; i++)
        {
            Vector3 vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            vertices[vertexIndex] = vertex;
            angle -= angleIncrease;
            triangles[triangleIndex + 0] = 0;
            triangles[triangleIndex + 1] = 0;
            triangles[triangleIndex + 2] = 0;
        }

        static Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

        }
        
        vertices[1] = new Vector3(50, 0);
        vertices[2] = new Vector3(0, -50);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
}
