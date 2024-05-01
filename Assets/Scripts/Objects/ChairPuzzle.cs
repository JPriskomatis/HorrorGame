using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairPuzzle : MonoBehaviour
{
    public List<int> correctChairs = new List<int> { 0, 3, 5, 7 };

    public List<int> playerChairs = new List<int>();


    public void AddChairToList(int chair)
    {
        playerChairs.Add(chair);
        AreListsIdentical();
    }

    public void RemoveChairFromList(int chair)
    {
        playerChairs.Remove(chair);
        AreListsIdentical();
    }


    public bool AreListsIdentical()
    {
        if (correctChairs.Count != playerChairs.Count)
        {
            return false;
        }

        for (int i = 0; i < correctChairs.Count; i++)
        {
            if (correctChairs[i] != playerChairs[i])
            {
                return false;
            }
        }
        Debug.Log("Puzzle has been solved!");
        return true;

    }

}
