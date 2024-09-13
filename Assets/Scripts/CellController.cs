using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    public int row;
    public int column;
    private Stack<char> piecesInside = new Stack<char>();
    private GameObject GetParentObject(GameObject other) =>
        other.transform.parent ? other.transform.parent.gameObject : other;

    private void OnTriggerEnter(Collider other)
    {
        GameObject parentObject = GetParentObject(other.gameObject);
        if (parentObject.CompareTag("x_piece"))
        {
            piecesInside.Push('x');
            BoardController.game.SetPosition(row, column, 'x');
        }
        else if (parentObject.CompareTag("o_piece"))
        {
            piecesInside.Push('o');
            BoardController.game.SetPosition(row, column, 'o');
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject parentObject = GetParentObject(other.gameObject);
        if (parentObject.CompareTag("x_piece") || parentObject.CompareTag("o_piece"))
        {
            char lastPiece = piecesInside.Pop();
            BoardController.game.SetPosition(row, column, piecesInside.Count == 0 ? ' ' : piecesInside.Peek()); 
        }
    }

}
