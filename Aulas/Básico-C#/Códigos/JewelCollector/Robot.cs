namespace JewelCollector;

public class Robot {
    private List<int> bag {get; set;}
    private int xPosition {get; set;}
    private int yPosition {get; set;}

    //Constructor:
    Robot(){
        this.bag = new List<int>();
        this.xPosition = 0;
        this.yPosition = 0;
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
        int red = 0, green = 0, blue = 0;
        for(int i = 0; i < bag.legth; i++){
            switch(bag[i].type){
                case "Red":
                    red += 1;
                    break;
                case "Green":
                    green += 1;
                    break;
                case "Blue":
                    blue += 1;
                    break;
            }
        }
        Console.WriteLine("Red jewels: " + red);
        Console.WriteLine("Green jewels: " + green);
        Console.WriteLine("Blue jewels: " + blue);
    }

    //Method that prints on the console the total number of points:
    public void totalPoints(){
        int points = 0;
        for(int i = 0; i < bag.length; i++){
            points += bag[i].value;
        }
        Console.WriteLine("Points: " + points);
    }
}
