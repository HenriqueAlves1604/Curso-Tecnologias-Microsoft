namespace JewelCollector;

public class Map {
    private readonly int MAP_ROWS;
    private readonly int MAP_COLS;
    public Item[][] map {get; set;}
    public Robot robot {get; set;}

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
                    Console.Write(map[i][j].ToString() + "  ");
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
                map[yPosition][xPosition] = new BlueJewel(xPosition, yPosition, this.robot);
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
                map[yPosition][xPosition] = new Tree(xPosition, yPosition, this.robot);
                break;
        }
    }

    //Methods that check if the movements are valid:
    public bool moveUpIsValid(int x, int y){
        try{
            bool valid = map[y - 1][x].transpassable;
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    public bool moveDownIsValid(int x, int y){
        try{
            bool valid = map[y + 1][x].transpassable;
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    public bool moveRightIsValid(int x, int y){
        try{
            bool valid = map[y][x + 1].transpassable;
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    public bool moveLeftIsValid(int x, int y){
        try{
            bool valid = map[y][x - 1].transpassable;
            return valid;
        }   catch(IndexOutOfRangeException) {
            return false;
        }
    }

    //Method that adds the robot to the map:
    public void addRobot(int xPosition, int yPosition){
        map[yPosition][xPosition] = this.robot;
    }

    //Method that checks if the game is over. If the player loses, returns -1; if the player wins returns 1; if it's not over, returns 0
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

    //Method that adds items randomly on the map:
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

    //Method that adds a generic item randomly on the map:
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

    //Methods that deals with the events:
    //Map's update when the robot moves up:
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

    //Updates the map when the robot moves down:
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

    //Updates the map when the robot moves right:
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

    //Updates the map when the robot moves left:
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

    //Updates the map when the robot collects an Item:
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
