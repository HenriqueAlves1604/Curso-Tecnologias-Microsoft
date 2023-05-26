namespace JewelCollector;

public class Map {
    private readonly int MAP_ROWS;
    private readonly int MAP_COLS;

    private string[][] map {get; set;}

    //Constructor:
    public Map(int rows, int cols){
        this.MAP_ROWS = rows;
        this.MAP_COLS = cols;
        map = new string[MAP_ROWS][];
        for(int i = 0; i < MAP_ROWS; i++){
            map[i] = new string[MAP_COLS];
            for(int j = 0; j < MAP_COLS; j++){
                this.map[i][j] = "--";
            }
        }
    }

    //Gets and Sets:
    public int getMAP_ROWS() {
        return this.MAP_ROWS;
    }
    public int getMAP_COLS() {
        return this.MAP_COLS;
    }

    public string[][] getMap() {
        return this.map;
    }

    public void setMap(string[][] map){
        this.map = map;
    }

    //Mathods:
    //Method that prints the map on the console:
    public void printMap(){
        for(int i = 0; i < MAP_ROWS; i++){
            Console.Write("\n");
            for(int j = 0; j < MAP_COLS; j++){
                Console.Write(map[i] [j] + "  ");
            }
        }
    }

    //Method that adds a jewel on the map:
    public void addJewel(string type, int xPosition, int yPosition){
        switch(type){
            case "Red":
                map[yPosition][xPosition] = "JR";
                return;
            case "Green":
                map[yPosition][xPosition] = "JG";
                return;
            case "Blue":
                map[yPosition][xPosition] = "JB";
                return;
        }
    }

    //Method that removes a jewel from the map:
    public void removeJewel(int xPosition, int yPosition){
        map[yPosition][xPosition] = "--";
    }

    //Method that adds an obstacle on the map:
    public void addObstacle(string type, int xPosition, int yPosition){
        switch(type){
            case "Water":
                map[yPosition][xPosition] = "##";
                break;
            case "Tree":
                map[yPosition][xPosition] = "$$";
                break;
        }
    }
}
