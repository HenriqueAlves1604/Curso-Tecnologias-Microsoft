namespace JewelCollector;

public class Tree : Item, IEnergizable {
    private Robot robot;
    private bool used;

    //Constructor:
    public Tree(int xPosition, int yPosition, Robot robot) : base(xPosition, yPosition, "$$", false, false) {
        this.robot = robot;
        this.used = false;
    }

    public void updateEnergy(){
        Console.WriteLine("before:" + used);
        Console.WriteLine("x,y:" + this.xPosition + this.yPosition);

        if(!used){
            robot.energy += 3;
            this.used = true;
        }
        Console.WriteLine("after:" + used);

    }
}
