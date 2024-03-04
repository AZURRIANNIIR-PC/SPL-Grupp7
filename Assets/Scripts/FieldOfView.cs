using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        //v�rden f�r field of view
        float fieldOfView = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 2;
        float angle = 0f;
        float angleIncrease = fieldOfView/ rayCount;
        float viewDistance = 50f;

        // v�ra rays best�r av vertiser, vilket vi skapar h�r nedan
        // v�r original vertis r�knas som 1, sedan beh�ver vi f�r en triangel skapa en vertis vid 90, 45 och 0 grader = 4
        // rayCount h�r, r�knar bara vertisen p� 90 och 45 grader, inte den p� 0 grader och original vertisen, d�rf�r st�r det inte bara 4 ist�llet f�r rayCount + 1 +1
        Vector3[] vertices = new Vector3[rayCount + 1 + 1]; 
        
        // v�r uv ska ha samma sak s� vi kan h�mta v�ra v�rden fr�n vertiserna f�r att hitta r�tt l�ngd
        Vector2[] uv = new Vector2[vertices.Length];

        // det ska va samma m�ngd trianglar som v�ra rays,
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        // g� igenom alla rays och l�gg placera vertiser p� r�tt position
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
