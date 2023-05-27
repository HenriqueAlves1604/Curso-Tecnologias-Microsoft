namespace JewelCollector;

public class Map {
    private readonly int MAP_ROWS;
    private readonly int MAP_COLS;
    private Item[][] map;
    private Robot robot;

    //Constructor:
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

    //Gets and Sets:
    public int getMAP_ROWS() {
        return this.MAP_ROWS;
    }
    public int getMAP_COLS() {
        return this.MAP_COLS;
    }

    //Mathods:
    //Method that prints the map on the console:
    public void printMap(){
        for(int i = 0; i < MAP_ROWS; i++){
            for(int j = 0; j < MAP_COLS; j++){
                try{
                    Console.Write(map[i][j].toString() + "  ");
                }   catch(System.NullReferenceException){
                    Console.WriteLine("Nenhum objeto na posição " + i + ", " + j);
                }
            }
            Console.Write("\n");
        }
    }

    //Method that adds a jewel on the map:
    public void addJewel(string type, int xPosition, int yPosition){
        switch(type){
            case "Red":
                map[yPosition][xPosition] = new RedJewel(xPosition, yPosition);
                break;
            case "Blue":
                map[yPosition][xPosition] = new BlueJewel(xPosition, yPosition);
                break;
            case "Green":
                map[yPosition][xPosition] = new GreenJewel(xPosition, yPosition);
                break;
        }
    }

    //Method that removes an Item from the map:
    public void removeItem(int xPosition, int yPosition){
        map[yPosition][xPosition] = new Empty(xPosition, yPosition);
    }

    //Method that adds an obstacle on the map:
    public void addObstacle(string type, int xPosition, int yPosition){
        switch(type){
            case "Water":
                map[yPosition][xPosition] = new Water(xPosition, yPosition);
                break;
            case "Tree":
                map[yPosition][xPosition] = new Tree(xPosition, yPosition);
                break;
        }
    }

    //Methods that check if the movements are valid:
    public bool moveUpIsValid(int x, int y){
        try{
            bool valid = map[y - 1][x].getTranspassable();
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    public bool moveDownIsValid(int x, int y){
        try{
            bool valid = map[y + 1][x].getTranspassable();
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    public bool moveRightIsValid(int x, int y){
        try{
            bool valid = map[y][x + 1].getTranspassable();
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    public bool moveLeftIsValid(int x, int y){
        try{
            bool valid = map[y][x - 1].getTranspassable();
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    //Method that adds the robot to the map:
    public void addRobot(int xPosition, int yPosition){
        map[yPosition][xPosition] = robot;
    }

    //Method that checks if the game is over. If the player loses, returns -1; if the player wins returns 1; if it's not over, returns 0
    public int checkGameOver(){
        if(robot.energy == 0) {
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

    //Method that adds items randomly on the map:
    public void fillMap(){
        int blueJAmount = (getMAP_COLS() * getMAP_ROWS() * 3) / 100; 
        int greenJAmount = (getMAP_COLS() * getMAP_ROWS() * 2) / 100; 
        int redJAmount = (getMAP_COLS() * getMAP_ROWS() * 2) / 100;
        int waterAmount = (getMAP_COLS() * getMAP_ROWS() * 7) / 100;
        int treeAmount = (getMAP_COLS() * getMAP_ROWS() * 7) / 100;

        addItemRandomly<BlueJewel>(new BlueJewel(0,0), blueJAmount);
        addItemRandomly<GreenJewel>(new GreenJewel(0,0), greenJAmount);
        addItemRandomly<RedJewel>(new RedJewel(0,0), redJAmount);
        addItemRandomly<Water>(new Water(0,0), waterAmount);
        addItemRandomly<Tree>(new Tree(0,0), treeAmount);
    }

    //Method that adds a generic item randomly on the map:
    public void addItemRandomly<T>(T item1, int amount) where T : Item{
        int count = 0;
        if(item1 is BlueJewel){
            Random random = new Random();
            int xPosition = random.Next(0,4);
            int yPosition = random.Next(0,4);
            map[yPosition][xPosition] = item1;
        }
        while(count < amount){
            Random random = new Random();
            int xPosition = random.Next(0, getMAP_COLS());  
            int yPosition = random.Next(0, getMAP_ROWS());
            if(map[yPosition][xPosition] is Empty){
                map[yPosition][xPosition] = item1;
                count++;
            }
        }
    }

    //Methods that deals with the events:
    //Map's update when the robot moves up:
    private void Robot_MovedUp(object? sender, EventArgs e){
        int x = robot.getXPosition();
        int y = robot.getYPosition();
        try{
            this.addRobot(x, y);
            map[y + 1][x] = new Empty(x, y + 1);
            robot.energy--;
        }   catch(IndexOutOfRangeException) {
            robot.setYPosition(y + 1);
        }
    }

    //Updates the map when the robot moves down:
    private void Robot_MovedDown(object? sender, EventArgs e){
        int x = robot.getXPosition();
        int y = robot.getYPosition();
        try{
            this.addRobot(x, y);
            map[y - 1][x] = new Empty(x, y - 1);
            robot.energy--;
        }   catch(IndexOutOfRangeException) {
            robot.setYPosition(y - 1);
        }
    }

    //Updates the map when the robot moves right:
    private void Robot_MovedRight(object? sender, EventArgs e){
        int x = robot.getXPosition();
        int y = robot.getYPosition();
        try{
            this.addRobot(x, y);
            map[y][x - 1] = new Empty(x - 1, y);
            robot.energy--;
        }   catch(IndexOutOfRangeException) {
            robot.setXPosition(x - 1);
        }
    }

    //Updates the map when the robot moves left:
    private void Robot_MovedLeft(object? sender, EventArgs e){
        int x = robot.getXPosition();
        int y = robot.getYPosition();
        try{
            this.addRobot(x, y);
            map[y][x + 1] = new Empty(x + 1, y);
            robot.energy--;
        }   catch(IndexOutOfRangeException) {
            robot.setXPosition(x + 1);
        }
    }

    //Updates the map when the robot collects an Item:
    private void Robot_Collected(object? sender, EventArgs e){
        int x = robot.getXPosition();
        int y = robot.getYPosition();
        int collected = 0;

        try{
            if(map[y][x + 1].getCollectable()){
                robot.bag.Add(map[y][x + 1]);
                map[y][x + 1] = new Empty(x + 1, y);
                collected++;
            }
        }   catch(IndexOutOfRangeException)  {}

        try{
            if(map[y][x - 1].getCollectable()){
                robot.bag.Add(map[y][x - 1]);
                map[y][x - 1] = new Empty(x - 1, y);
                collected++;
            }
        }   catch(IndexOutOfRangeException)  {}

        try{
            if(map[y + 1][x].getCollectable()){
                robot.bag.Add(map[y + 1][x]);
                map[y + 1][x] = new Empty(x, y + 1);
                collected++;
            }
        }   catch(IndexOutOfRangeException)  {}

        try{
            if(map[y - 1][x].getCollectable()){
                robot.bag.Add(map[y - 1][x]);
                map[y - 1][x] = new Empty(x, y - 1);
                collected++;
            }
        }   catch(IndexOutOfRangeException)  {}
        Console.WriteLine("AMT COLLECTED: " + collected);
        for(int i = robot.bag.Count - collected; i < robot.bag.Count; i++){
            Console.WriteLine(robot.bag[i]);
            if(robot.bag[i] is BlueJewel){
                robot.energy += 5;
            }   else if(robot.bag[i] is Tree){
                robot.energy += 3;
            }
        }
    }
}
