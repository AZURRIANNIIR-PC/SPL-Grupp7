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
        float fieldOfView = 17.5f;
        Vector3 origin = Vector3.zero;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fieldOfView / rayCount;
        float viewDistance = 12.5f;

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
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance);
            // If-satsen kollar efter kollisioner mellan synf�tet och omv�rlden, och anpassar synf�tet utefter detta

            // Debug log to print information about raycast hit
            if (raycastHit2D.collider != null)
            {
                Debug.Log("Ray hit: " + raycastHit2D.collider.gameObject.name + " at position: " + raycastHit2D.point);
            }

            if (raycastHit2D.collider == null)
            {
                // om det inte tr�ffar n�got s�tts vertisen d�r den va p� maximala distansen
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            } else {
                // om den tr�ffar n�got s�tter vi vertisen p� den punkt d�r det kolliderade
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            //detta kommer skapa triangeln baserat p� vertiserna, om  i > 0, f�r att detta inte kan k�ras p� den f�rsta ray:n d� den inte han en vertis att koppla till
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0; // vertisen p� origin
                triangles[triangleIndex + 1] = vertexIndex - 1; // vertisen innan
                triangles[triangleIndex + 2] = vertexIndex; // den nuvarande vertisen

                triangleIndex += 3;

            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        // konverterar vinkeln till en vector3
        static Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

        }

        /*vertices[1] = new Vector3(50, 0);
        vertices[2] = new Vector3(0, -50);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;*/

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
}