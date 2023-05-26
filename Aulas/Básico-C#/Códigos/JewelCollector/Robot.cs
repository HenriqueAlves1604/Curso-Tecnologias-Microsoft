namespace JewelCollector;

public class Robot {
    private List<Jewel> bag {get; set;}
    private int xPosition {get; set;}
    private int yPosition {get; set;}
    private Map map {get; set;}

    //Constructor:
    Robot(Map map){
        this.bag = new List<Jewel>();
        this.xPosition = 0;
        this.yPosition = 0;
        this.map = map;
    }

    //Method that moves the robot one unit up:
    public void moveUp(){
        this.yPosition += 1;
    }

    //Method that moves the robot one unit down:
    public void moveDown(){
        this.yPosition -= 1;
    }

    //Method that moves the robot one unit to the right:
    public void moveRight(){
        this.xPosition += 1;
    }

    //Method that moves the robot one unit to the right:
    public void moveLeft(){
        this.xPosition -= 1;
    }

    //Method that collects a jewel from the map:
    public void collectJewel(){
        
    }

    //Method that prints on the console the amount of jewels collected:
    public void jewelsCollected(){
        Console.WriteLine("Bag total items: " + bag.Count);
    }

    //Method that prints on the console the total number of points:
    public void totalPoints(){
        int points = 0;
        for(int i = 0; i < bag.Count; i++){
            points += bag[i].value();
        }
        Console.WriteLine("Bag total value: " + points);
    }
}
