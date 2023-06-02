namespace JewelCollector;

/// <summary>
/// Represents a robot in the game.
/// </summary>
public class Robot : Item{
    /// <summary>
    /// Gets or sets the bag of items collected by the robot.
    /// </summary>
    public List<Item> bag {get; set;}

    /// <summary>
    /// Gets or sets the energy of the robot.
    /// </summary>
    public int energy {get; set;}

    /// <summary>
    /// Event that is raised when the robot moves up.
    /// </summary>
    public event EventHandler? MovedUp;

    /// <summary>
    /// Event that is raised when the robot moves down.
    /// </summary>
    public event EventHandler? MovedDown;

    /// <summary>
    /// Event that is raised when the robot moves right.
    /// </summary>
    public event EventHandler? MovedRight;

    /// <summary>
    /// Event that is raised when the robot moves left.
    /// </summary>
    public event EventHandler? MovedLeft;

    /// <summary>
    /// Event that is raised when the robot collects an item.
    /// </summary>
    public event EventHandler? Collected;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Robot"/> class with the specified position, symbol and whether it is transpassable or collectable. It sets the robot's bag as an empty bag and sets its energy with the value 5.
    /// </summary>
    public Robot() : base(0, 0, "ME", true, false) {
        this.bag = new List<Item>();
        this.energy = 5;
    }

    /// <summary>
    /// Constructor for the Robot class with custom bag and energy values.
    /// </summary>
    /// <param name="bag">The bag of items collected by the robot.</param>
    /// <param name="energy">The energy level of the robot.</param>
    public Robot(List<Item> bag, int energy) : base(0, 0, "ME", true, false) {
        this.bag = bag;
        this.energy = energy;
    }

    /// <summary>
    /// Moves the robot one unit up.
    /// </summary>
    public void moveUp(){
        this.yPosition -= 1;
        OnMovedUp();
    }

    /// <summary>
    /// Raises the MovedUp event.
    /// </summary>
    protected virtual void OnMovedUp(){
        //Checks if there are subscribers
        if(MovedUp != null){
            //Calls the event
            MovedUp(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Moves the robot one unit down.
    /// </summary>
    public void moveDown(){
        this.yPosition += 1;
        OnMovedDown();
    }

    /// <summary>
    /// Raises the MovedDown event.
    /// </summary>
    protected virtual void OnMovedDown(){
        if(MovedDown != null){
            MovedDown(this, EventArgs.Empty);
        }
    }
    

    /// <summary>
    /// Moves the robot one unit to the right.
    /// </summary>
    public void moveRight(){
        this.xPosition += 1;
        OnMovedRight();
    }

    /// <summary>
    /// Raises the MovedRight event.
    /// </summary>
    protected virtual void OnMovedRight(){
        if(MovedRight != null){
            MovedRight(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Moves the robot one unit to the right.
    /// </summary>
    public void moveLeft(){
        this.xPosition -= 1;
        OnMovedLeft();
    }

    /// <summary>
    /// Raises the MovedLeft event.
    /// </summary>
    protected virtual void OnMovedLeft(){
        if(MovedLeft != null){
            MovedLeft(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Collects an item from the map.
    /// </summary>
    public void collect(){
        OnCollect();   
    }

    /// <summary>
    /// Raises the Collected event.
    /// </summary>
    protected virtual void OnCollect(){
        if(Collected != null){
            Collected(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Returns the number of jewels collected by the robot.
    /// </summary>
    /// <returns>A string representing the number of jewels collected.</returns>
    public string jewelsCollected(){
        return "Bag total items: " + bag.Count;
    }

    // <summary>
    /// Returns the total value of jewels collected by the robot.
    /// </summary>
    /// <returns>A string representing the total value of jewels collected.</returns>
    public string totalPoints(){
        int points = 0;
        for(int i = 0; i < bag.Count; i++){
            if(bag[i] is Jewel){
                points += ((Jewel) bag[i]).value;
            }
        }
        return "Bag total value: " + points;
    }
}
