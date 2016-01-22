using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class TicTacToe : System.Web.UI.Page
    {
        private static char[,] gameField;
        private int moves;
        private bool hasWinner;
        private const char PlayerSymbol = 'X';
        private const char ComputerSymbol = 'O';

        protected void Page_Load(object sender, EventArgs e)
        {
            gameField = new char[4, 4];

            ReadCells(GameField);
        }

        protected void CellClick(object sender, CommandEventArgs e)
        {
            var selectedRow = e.CommandArgument.ToString()[0] - 48;
            var selectedCol = e.CommandArgument.ToString()[1] - 48;

            if (gameField[selectedRow, selectedCol] == 0)
            {
                var cell = sender as Button;
                cell.Text = PlayerSymbol.ToString();
                gameField[selectedRow, selectedCol] = PlayerSymbol;

                CheckForWinner();

                if (moves == 8)
                {
                    PopUpMessage("NO WINNER.");
                }
                else
                {
                    if (!hasWinner)
                    {
                        ComputerMove();
                        CheckForWinner();
                    }
                }

            }

        }

        private void CheckForWinner()
        {
            // Check on rows & cols
            for (int col = 1; col <= 3; col++)
            {

                int xOnRow = 0;
                int oOnRow = 0;
                int xOnCol = 0;
                int oOnCol = 0;
                for (int row = 1; row <= 3; row++)
                {
                    var currentCell = gameField[row, col];
                    if (currentCell == PlayerSymbol)
                    {
                        xOnRow++;
                    }
                    else if (currentCell == ComputerSymbol)
                    {
                        oOnRow++;
                    }

                    currentCell = gameField[col, row];
                    if (currentCell == PlayerSymbol)
                    {
                        xOnCol++;
                    }
                    else if (currentCell == ComputerSymbol)
                    {
                        oOnCol++;
                    }

                }
                SendMessageIfHasWinner(xOnRow, oOnRow);
                SendMessageIfHasWinner(xOnCol, oOnCol);
            }

            // Check diagonals
            int xOnDiagonal1 = 0;
            int xOnDiagonal2 = 0;
            int oOnDiagonal1 = 0;
            int oOnDiagonal2 = 0;

            for (int i = 1; i <= 3; i++)
            {
                var currentCell = gameField[i, i];
                if (currentCell == PlayerSymbol)
                {
                    xOnDiagonal1++;
                }
                else if (currentCell == ComputerSymbol)
                {
                    oOnDiagonal1++;
                }

                currentCell = gameField[i, 4 - i];
                if (currentCell == PlayerSymbol)
                {
                    xOnDiagonal2++;
                }
                else if (currentCell == ComputerSymbol)
                {
                    oOnDiagonal2++;
                }
                SendMessageIfHasWinner(xOnDiagonal1, oOnDiagonal1);
                SendMessageIfHasWinner(xOnDiagonal2, oOnDiagonal2);
            }
        }

        private void SendMessageIfHasWinner(int playerCells, int computerCells)
        {
            if (!hasWinner)
            {
                if (playerCells == 3)
                {
                    PopUpMessage("Player Win.");
                    hasWinner = true;
                    return;
                }
                else if (computerCells == 3)
                {
                    PopUpMessage("Computer Win.");
                    hasWinner = true;
                    return;
                }
            }
        }


        private void PopUpMessage(string message)
        {
            GameForm.Controls.Add(new HtmlGenericControl("script") { InnerHtml = "alert('" + message + "');window.location='./4.TicTacToe.aspx';" });
        }

        private void ComputerMove()
        {
            // Check for next step win

            //// On cols
            for (int col = 1; col <= 3; col++)
            {

                if (CheckColForNextStepWin(col, ComputerSymbol))
                {
                    return;
                }
                if (CheckColForNextStepWin(col, PlayerSymbol))
                {
                    return;
                }
            }

            //// On rows
            for (int row = 1; row <= 3; row++)
            {
                if (CheckRowForNextStepWin(row, ComputerSymbol))
                {
                    return;
                }
                if (CheckRowForNextStepWin(row, PlayerSymbol))
                {
                    return;
                }
            }

            //// Check diagonals
            if (CheckDiagonalsForNextStepWin(ComputerSymbol))
            {
                return;
            }
            if (CheckDiagonalsForNextStepWin(PlayerSymbol))
            {
                return;
            }

            // Take Center or Random

            if (gameField[2, 2] == 0)
            {
                SetCell(2, 2, ComputerSymbol);
            }
            else
            {
                SetRandom();
            }
        }

        private void SetRandom()
        {
            var random = new Random();

            while (true)
            {
                int randomRow = random.Next(1, 4);
                int randomCol = random.Next(1, 4);

                if (gameField[randomRow, randomCol] == 0)
                {
                    SetCell(randomRow, randomCol, ComputerSymbol);
                    return;
                }
            }
        }

        private bool CheckDiagonalsForNextStepWin(char playerSymbol)
        {
            int xOnDiagonal1 = 0;
            int freeCellDiagonal1 = 0;
            int xOnDiagonal2 = 0;
            int freeCellDiagonal2 = 0;


            for (int i = 1; i <= 3; i++)
            {
                var currentCell = gameField[i, i];
                if (currentCell == playerSymbol)
                {
                    xOnDiagonal1++;
                }
                else if (currentCell == 0)
                {
                    freeCellDiagonal1 = i;
                }

                currentCell = gameField[i, 4 - i];
                if (currentCell == playerSymbol)
                {
                    xOnDiagonal2++;
                }
                else if (currentCell == 0)
                {
                    freeCellDiagonal2 = i;
                }

            }

            if (xOnDiagonal1 == 2 && freeCellDiagonal1 != 0)
            {
                SetCell(freeCellDiagonal1, freeCellDiagonal1, ComputerSymbol);
                return true;
            }

            if (xOnDiagonal2 == 2 && freeCellDiagonal2 != 0)
            {
                SetCell(freeCellDiagonal2, 4 - freeCellDiagonal2, ComputerSymbol);
                return true;
            }

            return false;
        }

        private bool CheckRowForNextStepWin(int row, char player)
        {
            int xOnRow = 0;
            int freeCell = 0;
            for (int col = 1; col <= 3; col++)
            {
                var currentCell = gameField[row, col];
                if (currentCell == player)
                {
                    xOnRow++;
                }
                else if (currentCell == 0)
                {
                    freeCell = col;
                }
            }
            if (xOnRow == 2 && freeCell != 0)
            {
                SetCell(row, freeCell, ComputerSymbol);
                return true;
            }

            return false;
        }

        private bool CheckColForNextStepWin(int col, char player)
        {
            int xOnCol = 0;
            int freeCell = 0;
            for (int row = 1; row <= 3; row++)
            {
                var currentCell = gameField[row, col];
                if (currentCell == player)
                {
                    xOnCol++;
                }
                else if (currentCell == 0)
                {
                    freeCell = row;
                }
            }

            if (xOnCol == 2 && freeCell != 0)
            {
                SetCell(freeCell, col, ComputerSymbol);
                return true;
            }

            return false;
        }

        private void SetCell(int row, int col, char symbol)
        {
            gameField[row, col] = symbol;
            FindCell("Cell" + row + col).Text = symbol.ToString();
        }

        private Button FindCell(string cell, Control control = null)
        {
            if (control == null)
            {
                control = GameField;
            }

            foreach (Control item in control.Controls)
            {
                if (item.Controls.Count != 0)
                {
                    var c = FindCell(cell, item);
                    if (c != null)
                    {
                        return c;
                    }
                }

                var button = item as Button;
                if (button != null && button.ID == cell)
                {
                    return button;
                }
            }

            return null;
        }

        private void ReadCells(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item.Controls.Count != 0)
                {
                    ReadCells(item);
                    continue;
                }

                var button = item as Button;
                if (button != null && button.ID.StartsWith("Cell"))
                {
                    var row = button.ID[4] - 48;
                    var col = button.ID[5] - 48;

                    if (button.Text != "")
                    {
                        gameField[row, col] = button.Text[0];
                        moves++;
                    }
                }
            }
        }
    }
}