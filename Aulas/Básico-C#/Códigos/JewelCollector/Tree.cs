namespace JewelCollector;

public class Tree : Item, IEnergizable {
    private Robot robot{get; set;}
    private bool used{get; set;}

    //Constructor:
    public Tree(int xPosition, int yPosition, Robot robot) : base(xPosition, yPosition, "$$", false, false) {
        this.robot = robot;
        this.used = false;
    }

    public void updateEnergy(){
        if(!used){
            robot.energy += 3;
            this.used = true;
        }
    }
}
