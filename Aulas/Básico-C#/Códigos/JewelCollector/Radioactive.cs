namespace JewelCollector;

public class Radioactive : Item {
    private Robot robot;

    //Construtor:
    public Radioactive(int xPosition, int yPosition, Robot robot) : base (xPosition, yPosition, "!!", true, false){
        this.robot = robot;
    }

    public static void updateEnergy(Map map){
        int x = map.robot.xPosition;
        int y = map.robot.yPosition;
        if(map.map[y][x] is Radioactive){
            map.robot.energy -= 30;
        }
        try{
            if(map.map[y + 1][x] is Radioactive){
            map.robot.energy -= 10;
            }
        }   catch(IndexOutOfRangeException){}

        try{
            if(map.map[y - 1][x] is Radioactive){
            map.robot.energy -= 10;
            }
        }   catch(IndexOutOfRangeException){}

        try{
            if(map.map[y][x + 1] is Radioactive){
            map.robot.energy -= 10;
            }
        }   catch(IndexOutOfRangeException){}

        try{
            if(map.map[y][x - 1] is Radioactive){
            map.robot.energy -= 10;
            }
        }   catch(IndexOutOfRangeException){}

    }



}
