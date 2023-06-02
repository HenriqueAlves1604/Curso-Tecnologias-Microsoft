namespace JewelCollector;

/// <summary>
/// Represents the game map.
/// </summary>
public class Map {
    /// <summary>
    /// The number of rows in the map.
    /// </summary>
    private readonly int MAP_ROWS;

    /// <summary>
    /// The number of columns in the map.
    /// </summary>
    private readonly int MAP_COLS;

    /// <summary>
    /// The map grid containing items.
    /// </summary>
    public Item[][] map {get; set;}

    /// <summary>
    /// The robot in the game.
    /// </summary>
    public Robot robot {get; set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="Map"/> class with its amount of rows, columns and with its robot.
    /// </summary>
    /// <param name="rows">The number of rows in the map.</param>
    /// <param name="cols">The number of columns in the map.</param>
    /// <param name="robot">The robot in the game.</param>
    public Map(int rows, int cols, Robot robot){
        this.MAP_ROWS = rows;
        this.MAP_COLS = cols;
        map = new Item[MAP_ROWS][];
        for(int i = 0; i < MAP_ROWS; i++){
            map[i] = new Item[MAP_COLS];
            for(int j = 0; j < MAP_COLS; j++){
                this.map[i][j] = new Empty(j, i);
            }
        }
        this.robot = robot;
        this.addRobot(0,0);
        robot.MovedUp += Robot_MovedUp;
        robot.MovedDown += Robot_MovedDown;
        robot.MovedRight += Robot_MovedRight;
        robot.MovedLeft += Robot_MovedLeft;
        robot.Collected += Robot_Collected;
    }

    /// <summary>
    /// Gets the number of rows in the map.
    /// </summary>
    /// <returns>The number of rows in the map.</returns>
    public int getMAP_ROWS() {
        return this.MAP_ROWS;
    }

    /// <summary>
    /// Gets the number of columns in the map.
    /// </summary>
    /// <returns>The number of rows in the map.</returns>
    public int getMAP_COLS() {
        return this.MAP_COLS;
    }

    /// <summary>
    /// Prints the map on the console.
    /// </summary>
    public void printMap(){
        for(int i = 0; i < MAP_ROWS; i++){
            for(int j = 0; j < MAP_COLS; j++){
                try{
                    Console.Write(map[i][j].ToString() + "  ");
                }   catch(System.NullReferenceException){
                    Console.WriteLine("Nenhum objeto na posição " + i + ", " + j);
                }
            }
            Console.Write("\n");
        }
    }

    /// <summary>
    /// Checks if moving up is a valid move.
    /// </summary>
    /// <param name="x">The current x-position of the robot.</param>
    /// <param name="y">The current y-position of the robot.</param>
    /// <returns>True if moving up is valid, false otherwise.</returns>
    public bool moveUpIsValid(int x, int y){
        try{
            bool valid = map[y - 1][x].transpassable;
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    /// <summary>
    /// Checks if moving down is a valid move.
    /// </summary>
    /// <param name="x">The current x-position of the robot.</param>
    /// <param name="y">The current y-position of the robot.</param>
    /// <returns>True if moving down is valid, false otherwise.</returns>
    public bool moveDownIsValid(int x, int y){
        try{
            bool valid = map[y + 1][x].transpassable;
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    /// <summary>
    /// Checks if moving right is a valid move.
    /// </summary>
    /// <param name="x">The current x-position of the robot.</param>
    /// <param name="y">The current y-position of the robot.</param>
    /// <returns>True if moving right is valid, false otherwise.</returns>
    public bool moveRightIsValid(int x, int y){
        try{
            bool valid = map[y][x + 1].transpassable;
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    /// <summary>
    /// Checks if moving left is a valid move.
    /// </summary>
    /// <param name="x">The current x-position of the robot.</param>
    /// <param name="y">The current y-position of the robot.</param>
    /// <returns>True if moving left is valid, false otherwise.</returns>
    public bool moveLeftIsValid(int x, int y){
        try{
            bool valid = map[y][x - 1].transpassable;
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    /// <summary>
    /// Adds the robot to the map.
    /// </summary>
    /// <param name="xPosition">The x-position where the robot will be added.</param>
    /// <param name="yPosition">The y-position where the robot will be added.</param>
    public void addRobot(int xPosition, int yPosition){
        map[yPosition][xPosition] = this.robot;
    }

    /// <summary>
    /// Checks if the game is over.
    /// </summary>
    /// <returns>-1 if the player loses, 1 if the player wins, 0 if the game is not over.</returns>
    public int checkGameOver(){
        if(robot.energy <= 0) {
            Console.WriteLine("NO ENERGY! YOU LOST!");
            return -1;
        }
        for(int i = 0; i < MAP_ROWS; i++){
            for(int j = 0; j < MAP_COLS; j++){
                if(map[i][j] is Jewel){
                    return 0;
                }
            }
        }
        Console.WriteLine("YOU WON!\n");
        return 1;
    }

    ///<summary>
    /// Adds items randomly on the map.
    /// </summary>
    /// <param name="firstPhase">Indicates if it's the first phase of the game.</param>
    public void fillMap(bool firstPhase){
        int i = 0;
        int blueJAmount = (getMAP_COLS() * getMAP_ROWS() * 5) / 100; 
        int greenJAmount = (getMAP_COLS() * getMAP_ROWS() * 2) / 100; 
        int redJAmount = (getMAP_COLS() * getMAP_ROWS() * 2) / 100;
        int waterAmount = (getMAP_COLS() * getMAP_ROWS() * 4) / 100;
        int treeAmount = (getMAP_COLS() * getMAP_ROWS() * 7) / 100;

        while(i < blueJAmount){
            addItemRandomly<BlueJewel>(new BlueJewel(0,0, this.robot));
            i++;
        }
        i = 0;

        while(i < greenJAmount){
            addItemRandomly<GreenJewel>(new GreenJewel(0,0));
            i++;
        }
        i = 0;

        while(i < redJAmount){
            addItemRandomly<RedJewel>(new RedJewel(0,0));
            i++;
        }
        i = 0;

        while(i < waterAmount){
            addItemRandomly<Water>(new Water(0,0));
            i++;
        }
        i = 0;

        while(i < treeAmount){
            addItemRandomly<Tree>(new Tree(0,0, this.robot));
            i++;
        }
        i = 0;
        
        
        if(!firstPhase){
            int radioactiveAmount = (getMAP_COLS() * getMAP_ROWS() * 1) / 100;
            
            while(i < radioactiveAmount){
                addItemRandomly<Radioactive>(new Radioactive(0, 0));
                i++;
            }
        i = 0;
        }
    }

    /// <summary>
    /// Adds a generic item randomly on the map.
    /// </summary>
    /// <typeparam name="T">The type of the item.</typeparam>
    /// <param name="item1">The item to be added.</param>
    public void addItemRandomly<T>(T item1) where T : Item{
        bool mt = false;
        while(mt == false){
            Random random = new Random();
            int xPosition = random.Next(0, getMAP_COLS());  
            int yPosition = random.Next(0, getMAP_ROWS());
            if(map[yPosition][xPosition] is Empty){
                item1.xPosition = xPosition;
                item1.yPosition = yPosition;
                map[yPosition][xPosition] = item1;
                mt = true;
            }
        }
    }

    /// <summary>
    /// Updates the map and the robot's energy when it moves up.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void Robot_MovedUp(object? sender, EventArgs e){
        int x = robot.xPosition;
        int y = robot.yPosition;
        Radioactive.updateEnergy(this);
        try{
            this.addRobot(x, y);
            map[y + 1][x] = new Empty(x, y + 1);
            robot.energy--;
        }   catch(IndexOutOfRangeException) {
            robot.yPosition++;
        }
    }

    /// <summary>
    /// Updates the map and the robot's energy when it moves down.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void Robot_MovedDown(object? sender, EventArgs e){
        int x = robot.xPosition;
        int y = robot.yPosition;
        Radioactive.updateEnergy(this);

        try{
            this.addRobot(x, y);
            map[y - 1][x] = new Empty(x, y - 1);
            robot.energy--;
        }   catch(IndexOutOfRangeException) {
            robot.yPosition--;
        }
    }

    /// <summary>
    /// Updates the map and the robot's energy when it moves right.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void Robot_MovedRight(object? sender, EventArgs e){
        int x = robot.xPosition;
        int y = robot.yPosition;
        Radioactive.updateEnergy(this);

        try{
            this.addRobot(x, y);
            map[y][x - 1] = new Empty(x - 1, y);
            robot.energy--;
        }   catch(IndexOutOfRangeException) {
            robot.xPosition--;
        }
    }

    /// <summary>
    /// Updates the map and the robot's energy when it moves up.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void Robot_MovedLeft(object? sender, EventArgs e){
        int x = robot.xPosition;
        int y = robot.yPosition;
        Radioactive.updateEnergy(this);

        try{
            this.addRobot(x, y);
            map[y][x + 1] = new Empty(x + 1, y);
            robot.energy--;
        }   catch(IndexOutOfRangeException) {
            robot.xPosition++;
        }
    }

    /// <summary>
    /// Updates the map and the robot's energy when it collects an item.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void Robot_Collected(object? sender, EventArgs e){
        int x = robot.xPosition;
        int y = robot.yPosition;

        try{
            if(map[y][x + 1] is IEnergizable && map[y][x + 1] is not Radioactive){
                (map[y][x + 1] as IEnergizable)?.updateEnergy();
            }
            if(map[y][x + 1].collectable){
                robot.bag.Add(map[y][x + 1]);
                map[y][x + 1] = new Empty(x + 1, y);
            }
        }   catch(IndexOutOfRangeException)  {}

        try{
            if(map[y][x - 1] is IEnergizable && map[y][x - 1] is not Radioactive){
                (map[y][x - 1] as IEnergizable)?.updateEnergy();
            }
            if(map[y][x - 1].collectable){
                robot.bag.Add(map[y][x - 1]);
                map[y][x - 1] = new Empty(x - 1, y);
            }
        }   catch(IndexOutOfRangeException)  {}

        try{
            if(map[y + 1][x] is IEnergizable && map[y + 1][x] is not Radioactive){
                (map[y + 1][x] as IEnergizable)?.updateEnergy();
            }
            if(map[y + 1][x].collectable){
                robot.bag.Add(map[y + 1][x]);
                map[y + 1][x] = new Empty(x, y + 1);
            }
        }   catch(IndexOutOfRangeException)  {}

        try{
            if(map[y - 1][x] is IEnergizable && map[y - 1][x] is not Radioactive){
                (map[y - 1][x] as IEnergizable)?.updateEnergy();
            }
            if(map[y - 1][x].collectable){
                robot.bag.Add(map[y - 1][x]);
                map[y - 1][x] = new Empty(x, y - 1);
            }
        }   catch(IndexOutOfRangeException)  {}
    }
}
