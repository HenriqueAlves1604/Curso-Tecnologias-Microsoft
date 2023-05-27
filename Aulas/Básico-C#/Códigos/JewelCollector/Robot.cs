namespace JewelCollector;

public class Robot : Item{
    private List<Item> bag;
    private int energy;

    //Declarating the events:
    public event EventHandler? MovedUp;
    public event EventHandler? MovedDown;
    public event EventHandler? MovedRight;
    public event EventHandler? MovedLeft;
    public event EventHandler? Collected;
    

    //Constructor:
    public Robot() : base(0, 0, "ME", true, false) {
        this.bag = new List<Item>();
        this.energy = 3;
    }

    //Gets and sets:
    public List<Item> getBag() {
        return this.bag;
    }

    public void setBag(List<Item> bag){
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
    public int getEnergy() {
        return this.energy;
    }

    public void setEnergy(int energy){
        this.energy = energy;
    }

    

    //Methods:
    //Method that moves the robot one unit up:
    public void moveUp(){
        this.yPosition -= 1;
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
        OnMovedLeft();
    }

    protected virtual void OnMovedLeft(){
        if(MovedLeft != null){
            MovedLeft(this, EventArgs.Empty);
        }
    }

    //Method that collects a jewel from the map:
    public void collect(){
        OnCollect();
        
    }

    protected virtual void OnCollect(){
        if(Collected != null){
            Collected(this, EventArgs.Empty);
        }
    }

    //Method that returns the amount of jewels collected:
    public string jewelsCollected(){
        return "Bag total items: " + bag.Count;
    }

    //Method that returns the total number of points:
    public string totalPoints(){
        int points = 0;
        for(int i = 0; i < bag.Count; i++){
            if(bag[i] is Jewel){
                points += ((Jewel) bag[i]).getValue();
            }
        }
        return "Bag total value: " + points;
    }
}
