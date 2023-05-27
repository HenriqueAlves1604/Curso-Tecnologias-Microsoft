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
        this.map[0][0] = robot;
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

    public Item[][] getMap() {
        return this.map;
    }

    public void setMap(Item[][] map){
        this.map = map;
    }

    public Robot getRobot() {
        return this.robot;
    }

    public void setRobot(Robot robot) {
        this.removeItem(getRobot().getXPosition(),getRobot().getYPosition());
        this.robot = robot;
        this.addRobot(getRobot().getXPosition(),getRobot().getYPosition());
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
        if(robot.getEnergy() == 0)  return -1;
        for(int i = 0; i < MAP_ROWS; i++){
            for(int j = 0; j < MAP_COLS; j++){
                if(map[i][j] is Jewel){
                    return 0;
                }
            }
        }
        return 1;
    }

    //Method that adds jewels randomly on the map:
    public void addJewelRandomly(){
        int blueAmount = (getMAP_COLS() * getMAP_ROWS() * 3) / 100; 
        int greenAmount = (getMAP_COLS() * getMAP_ROWS() * 2) / 100; 
        int redAmount = (getMAP_COLS() * getMAP_ROWS() * 2) / 100;
        int waterAmount = (getMAP_COLS() * getMAP_ROWS() * 7) / 100;
        int treeAmount = (getMAP_COLS() * getMAP_ROWS() * 5) / 100; 
    }

    //Method that adds obstacles randomly on the map:
    public void addObstaclesRandomly(){

    }

    //Methods that deals with the events:
    //Map's update when the robot moves up:
    private void Robot_MovedUp(object? sender, EventArgs e){
        int x = robot.getXPosition();
        int y = robot.getYPosition();
        try{
            this.addRobot(x, y);
            map[y + 1][x] = new Empty(x, y + 1);
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
        }   catch(IndexOutOfRangeException) {
            robot.setXPosition(x + 1);
        }
    }

    //Updates the map when the robot collects an Item:
    private void Robot_Collected(object? sender, EventArgs e){
        int x = robot.getXPosition();
        int y = robot.getYPosition();
        List<Item> newBag = robot.getBag();

        try{
            if(map[y][x + 1].getCollectable()){
                newBag.Add(map[y][x + 1]);
                robot.setBag(newBag);
                map[y][x + 1] = new Empty(x + 1, y);
            }
        }   catch(IndexOutOfRangeException)  {}

        try{
            if(map[y][x - 1].getCollectable()){
                newBag.Add(map[y][x - 1]);
                robot.setBag(newBag);
                map[y][x - 1] = new Empty(x - 1, y);
            }
        }   catch(IndexOutOfRangeException)  {}

        try{
            if(map[y + 1][x].getCollectable()){
                newBag.Add(map[y + 1][x]);
                robot.setBag(newBag);
                map[y + 1][x] = new Empty(x, y + 1);
            }
        }   catch(IndexOutOfRangeException)  {}

        try{
            if(map[y - 1][x].getCollectable()){
                newBag.Add(map[y - 1][x]);
                robot.setBag(newBag);
                map[y - 1][x] = new Empty(x, y - 1);
            }
        }   catch(IndexOutOfRangeException)  {}

    }
}
