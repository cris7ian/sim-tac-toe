using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    public int row;
    public int column;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameObject parentObject = other.gameObject.transform.parent ? other.gameObject.transform.parent.gameObject : other.gameObject;
        Debug.Log(parentObject.tag);

        if (parentObject.CompareTag("x_piece"))
        {
            BoardController.game.SetPosition(row, column, 'x');
        }
        else if (parentObject.CompareTag("o_piece"))
        {
            BoardController.game.SetPosition(row, column, 'o');
        }
    }

    // Called when another object exits the trigger
    private void OnTriggerExit(Collider other)
    {
        BoardController.game.SetPosition(row, column, ' ');
    }
}
