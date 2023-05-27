namespace JewelCollector;

public class Map {
    private readonly int MAP_ROWS;
    private readonly int MAP_COLS;

    private Item[][] map {get; set;}

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
        map[0][0] = new Robot(this);
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

    //Method that removes a jewel from the map:
    public void removeJewel(int xPosition, int yPosition){
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
}
