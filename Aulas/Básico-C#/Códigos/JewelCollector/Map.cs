namespace JewelCollector;

public class Map {
    private readonly int MAP_ROWS;
    private readonly int MAP_COLS;
    private Item[][] map;
    private Robot robot;

    //Constructor:
    public Map(int rows, int cols){
        this.MAP_ROWS = rows;
        this.MAP_COLS = cols;
        map = new Item[MAP_ROWS][];
        for(int i = 0; i < MAP_ROWS; i++){
            map[i] = new Item[MAP_COLS];
            for(int j = 0; j < MAP_COLS; j++){
                this.map[i][j] = new Empty(j, i);
            }
        }
        robot = new Robot();
        this.addRobot(0,0);
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
        Console.WriteLine("ROBO ANTES: X = " + getRobot().getXPosition() + ", Y = " + getRobot().getYPosition());
        this.removeItem(getRobot().getXPosition(),getRobot().getYPosition());
        this.robot = robot;
        Console.WriteLine("ROBO DEPOIS: X = " + getRobot().getXPosition() + ", Y = " + getRobot().getYPosition());
        this.addRobot(getRobot().getXPosition(),getRobot().getYPosition());
    }

    //Mathods:
    //Method that prints the map on the console:
    public void printMap(){
        for(int i = 0; i < MAP_ROWS; i++){
            for(int j = 0; j < MAP_COLS; j++){
                Console.Write(map[i][j].toString() + "  ");
            }
            Console.Write("\n");
        }
    }

    //Method that adds a jewel on the map:
    public void addJewel(string type, int xPosition, int yPosition){
        map[yPosition][xPosition] = new Jewel(type, xPosition, yPosition);
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

    //Method that adds the robot to the map:
    public void addRobot(int xPosition, int yPosition){
        map[yPosition][xPosition] = robot;
    }
}
