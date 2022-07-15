class Board
{

    private int spaces = 9;
    private string selected = "";
    private int player = 1;

    /* public Board(int spaces, int selected, int player) {
        spaces = spaces;
        selected = selected;
        player = player;
    } */

    public int Spaces
    {
        get { return spaces; }
        set { spaces = value; }
    } 

    public string Selected
    { 
        get { return selected; }
        set { selected = value; }
    }

    public int Player 
    { 
        get { return player; }
        set { player = value; }
    }



}