namespace JewelCollector;

/// <summary>
/// CClass responsible for the main execution of the JewelCollector game.
/// </summary>
public class AppMain {

    /// <summary>
    /// The main method that starts the JewelCollector game.
    /// </summary>
    public static void Main() {
        bool running = true;
        int gameOver, rows = 10, cols = 10;
        Robot robot = new Robot();
        
        Map map = new Map(rows, cols, robot);
        map.fillMap(true);

        do {
            map.printMap();
            Console.Write("Enter the command: ");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            Console.WriteLine("");
            char command = pressedKey.KeyChar;
            int robotX = robot.xPosition;
            int robotY = robot.yPosition;

            switch(command) {
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
            string energy = "Energy: " + robot.energy;
            Console.WriteLine(jewels + " | " + points + " | " + energy + "\n");

            gameOver = map.checkGameOver();
            if(gameOver == 1){
                if(rows == 30){
                    Console.WriteLine("CONGRATULATIONS! YOU BEAT THE GAME!!!");
                    break;
                }
                Console.WriteLine("YOU WON! PLAY AGAIN IN A BIGGER MAP!\n");
                gameOver = 0;
                robot = new Robot(robot.bag, robot.energy);
                map = new Map(++rows, ++cols, robot);
                map.fillMap(false);
            }   else if(gameOver == -1){
                Console.WriteLine("NO ENERGY! YOU LOST!");
            }

        } while (gameOver != -1 && running);
    }
}