namespace JewelCollector;
public class AppMain {

    public static void Main() {
        bool running = true;
        Map map = new Map(10,10);
        Robot robot = new Robot(map);

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
            Console.WriteLine("Enter the command: ");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            char command = pressedKey.KeyChar;
            
            switch(command){
                case 'w':
                    robot.moveUp();
                    break;
                case 'a':
                    robot.moveLeft();
                    break;
                case 's':
                    robot.moveDown();
                    break;
                case 'd':
                    robot.moveRight();
                    break;
                case 'g':
                    robot.collectJewel();
                    break;
                case 'q':
                    running = false;
                    break;
            }
            
            robot.jewelsCollected();
            Console.Write(" | ");
            robot.totalPoints();
        } while (running);
    }
}