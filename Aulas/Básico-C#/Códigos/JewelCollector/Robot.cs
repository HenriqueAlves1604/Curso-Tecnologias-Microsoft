namespace JewelCollector;

public class Robot : Item{
    private List<Jewel> bag;
    private int xPosition;
    private int yPosition;

    //Declarating the events:
    public event EventHandler? MovedUp;
    public event EventHandler? MovedDown;
    public event EventHandler? MovedRight;
    public event EventHandler? MovedLeft;
    

    //Constructor:
    public Robot() : base("ME") {
        this.bag = new List<Jewel>();
        this.xPosition = 0;
        this.yPosition = 0;
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

    public void setXPosition(int xPosition){
        this.xPosition = xPosition;
    }

    public int getYPosition() {
        return this.yPosition;
    }

    public void setYPosition(int yPosition){
        this.yPosition = yPosition;
    }

    

    //Methods:
    //Method that moves the robot one unit up:
    public void moveUp(){
        this.yPosition -= 1;
        Console.WriteLine(this.yPosition);
        OnMovedUp();
    }

    protected virtual void OnMovedUp(){
        //Checks if there are subscribers
        if(MovedUp != null){
            //Calls the event
            MovedUp(this, EventArgs.Empty);
        }
    }

    //Method that moves the robot one unit down:
    public void moveDown(){
        this.yPosition += 1;
        Console.WriteLine(this.yPosition);
        OnMovedDown();
    }

    protected virtual void OnMovedDown(){
        if(MovedDown != null){
            MovedDown(this, EventArgs.Empty);
        }
    }
    

    //Method that moves the robot one unit to the right:
    public void moveRight(){
        this.xPosition += 1;
        Console.WriteLine(this.xPosition);
        OnMovedRight();
    }

    protected virtual void OnMovedRight(){
        if(MovedRight != null){
            MovedRight(this, EventArgs.Empty);
        }
    }

    //Method that moves the robot one unit to the left:
    public void moveLeft(){
        this.xPosition -= 1;
        Console.WriteLine(this.xPosition);
        OnMovedLeft();
    }

    protected virtual void OnMovedLeft(){
        if(MovedLeft != null){
            MovedLeft(this, EventArgs.Empty);
        }
    }

    //Method that collects a jewel from the map:
    public void collectJewel(){
        
    }

    //Method that returns the amount of jewels collected:
    public string jewelsCollected(){
        return "Bag total items: " + bag.Count;
    }

    //Method that returns the total number of points:
    public string totalPoints(){
        int points = 0;
        for(int i = 0; i < bag.Count; i++){
            points += bag[i].getValue();
        }
        return "Bag total value: " + points;
    }
}
