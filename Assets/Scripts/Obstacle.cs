using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour, IProcess
{
    /*public Transform Plane;
    public Vector3 Pos;

    public struct Coordinates
    {
        public int x;
        public int y;

        public Coordinates(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    public static T[] ShuffleArray<T>(T[] array, int seed)
    {
        // ���� ���� ������
        System.Random prng = new System.Random(seed);

        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = prng.Next(i, array.Length);
            T tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem;
        }

        return array;




        List<Coordinates>


        PlaneCoords = new List<Coordinates>();*/

       

   




    //------------------------------------------------------//
    IProcess process = null;
    void Start()
    {
        process = gameObject.GetComponent<IProcess>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Do();
        }
    }

    private void Do()
    {
        process.player.speed *= 0.5f;
    }

    
}
