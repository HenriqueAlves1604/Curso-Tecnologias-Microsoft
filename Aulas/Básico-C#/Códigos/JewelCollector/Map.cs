namespace JewelCollector;

public class Map {
    private readonly int MAP_ROWS = 10;
    private readonly int MAP_COLS = 10;

    private string[][] map {get; set;}

    //Constructor:
    Map(){
        for(int i = 0; i < MAP_ROWS; i++){
            for(int j = 0; j < MAP_COLS; j++){
                map[i, j] = "--";
            }
        }
    }

    //Method that prints the map on the console:
    public void printMap(){
        for(int i = 0; i < MAP_ROWS; i++){
            Console.Write("\n");
            for(int j = 0; j < MAP_COLS; j++){
                Console.Write(map[i, j] + "  ");
            }
        }
    }

    //Method that adds a jewel on the map:
    public void addJewel(string type, int xPosition, int yPosition){
        switch(type){
            case "Red":
                map[yPosition, xPosition] = "JR";
                return;
            case "Green":
                map[yPosition, xPosition] = "JG";
                return;
            case "Blue":
                map[yPosition, xPosition] = "JB";
                return;
        }
    }

    //Method that removes a jewel from the map:
    public void removeJewel(int xPosition, int yPosition){
        map[yPosition, xPosition] = "--";
    }

    //Method that adds an obstacle on the map:
    public void removeObstacle(int xPosition, int yPosition){
        switch(type){
            case "Water":
                map[yPosition, xPosition] = "##";
                break;
            case "Tree":
                map[yPosition, xPosition] = "$$";
                break;
        }
    }
}
