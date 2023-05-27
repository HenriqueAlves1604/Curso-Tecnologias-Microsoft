namespace JewelCollector;
public class AppMain {

    public static void Main() {
        bool running = true;
        int gameOver, rows = 10, cols = 10;
        Robot robot = new Robot();
        
        Map map = new Map(rows, cols, robot);

        //Adding jewels on the map:
        map.addJewel("Red", 1, 9);
        map.addJewel("Red", 8, 8);
        map.addJewel("Green", 9, 1);
        map.addJewel("Green", 7, 6);
        map.addJewel("Blue", 3, 4);
        map.addJewel("Blue", 2, 1);

        //Adding obstacles on the map:
        for(int i = 0; i < 7; i++){
            map.addObstacle("Water", 5, i);
        }
        map.addObstacle("Tree", 5, 9);
        map.addObstacle("Tree", 3, 9);
        map.addObstacle("Tree", 8, 3);
        map.addObstacle("Tree", 2, 5);
        map.addObstacle("Tree", 1, 4);
  
    
        do {
            map.printMap();
            Console.Write("Enter the command: ");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            Console.WriteLine("");
            char command = pressedKey.KeyChar;
            int robotX = robot.getXPosition();
            int robotY = robot.getYPosition();

            switch(command){
                case 'w':
                    if(map.moveUpIsValid(robotX, robotY)){
                        robot.moveUp();
                    }
                    break;
                case 'a':
                    if(map.moveLeftIsValid(robotX, robotY)){
                        robot.moveLeft();
                    }
                    break;
                case 's':
                    if(map.moveDownIsValid(robotX, robotY)){
                        robot.moveDown();
                    }
                    break;
                case 'd':
                    if(map.moveRightIsValid(robotX, robotY)){                
                        robot.moveRight();
                    }
                    break;
                case 'g':
                    robot.collect();
                    break;
                case 'q':
                    running = false;
                    break;
            }

            string jewels = robot.jewelsCollected();
            string points = robot.totalPoints();
            Console.WriteLine(jewels + " | " + points + "\n");

            gameOver = map.checkGameOver();
            if(gameOver == 1){
                rows += 1;
                cols += 1;
                gameOver = 0;
                map = new Map(rows, cols, robot);
            }

        } while (gameOver != -1 && running);
    }
}