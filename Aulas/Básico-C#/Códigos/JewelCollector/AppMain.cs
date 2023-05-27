namespace JewelCollector;
public class AppMain {

    public static void Main() {
        bool running = true;
        Map map = new Map(10,10);

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
            
            switch(command){
                case 'w':
                    map.getRobot().moveUp();
                    break;
                case 'a':
                    map.getRobot().moveLeft();
                    break;
                case 's':
                    map.getRobot().moveDown();
                    break;
                case 'd':
                    map.getRobot().moveRight();
                    break;
                case 'g':
                    map.getRobot().collectJewel();
                    break;
                case 'q':
                    running = false;
                    break;
            }
            string jewels = map.getRobot().jewelsCollected();
            string points = map.getRobot().totalPoints();
            Console.WriteLine(jewels + " | " + points + "\n");
            
        } while (running);
    }
}