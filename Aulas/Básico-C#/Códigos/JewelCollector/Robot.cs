namespace JewelCollector;

public class Robot : Item{
    private List<Jewel> bag;
    private int xPosition;
    private int yPosition;
    private Map map;

    //Constructor:
    public Robot(Map map) : base("ME") {
        this.bag = new List<Jewel>();
        this.xPosition = 0;
        this.yPosition = 0;
        this.map = map;
    }

    //Gets and sets:
    public List<Jewel> getBag() {
        return this.bag;
    }

    public void setBag(List<Jewel> bag){
        this.bag = bag;
    }

    public int getXPosition() {
        return this.xPosition;
    }

    public void setXPosition(int yPosition){
        this.yPosition = yPosition;
    }

    public int getYPosition() {
        return this.xPosition;
    }

    public void setYPosition(int yPosition){
        this.yPosition = yPosition;
    }

    public Map getMap() {
        return this.map;
    }

    public void setMap(Map map){
        this.map = map;
    }
    

    //Methods:
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
            points += bag[i].getValue();
        }
        Console.WriteLine("Bag total value: " + points);
    }
}
