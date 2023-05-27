namespace JewelCollector;

public class Tree : Item, ICollectable {
    //Constructor:
    public Tree(int xPosition, int yPosition) : base(xPosition, yPosition, "$$", false, true) {}

    public void collect(){
        
    }
}
